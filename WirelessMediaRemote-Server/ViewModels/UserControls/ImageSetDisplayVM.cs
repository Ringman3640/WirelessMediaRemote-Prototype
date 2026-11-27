using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModels.Services;

namespace ViewModels.UserControls;

public partial class ImageSetDisplayVM : ObservableObject
{
    [ObservableProperty]
    private bool _displayActive = false;

    [ObservableProperty]
    private BitmapImage? _currentImageBitmap = null;

    [ObservableProperty]
    private bool _currentImageIsAnimated = false;

    private readonly IImageSetService _imageSetService;

    private readonly Size _displaySize;

    public ImageSetDisplayVM(Size displaySize, IImageSetService imageSetService)
    {
        _displaySize = displaySize;
        _imageSetService = imageSetService;

        _imageSetService.ImagePathsChanged += OnImagePathsChanged;
        _imageSetService.CurrentIndexChanged += LoadCurrentImageBitmap;

        OnImagePathsChanged();
    }

    private void OnImagePathsChanged()
    {
        if (_imageSetService.ImagePaths is null)
        {
            CurrentImageBitmap = null;
            DisplayActive = false;
            return;
        }

        LoadCurrentImageBitmap();
        DisplayActive = true;
    }

    private void LoadCurrentImageBitmap()
    {
        int currentIndex = _imageSetService.CurrentIndex;
        List<string>? imagePaths = _imageSetService.ImagePaths;
        if (imagePaths is null)
        {
            return;
        }
        if (currentIndex < 0 || currentIndex > imagePaths.Count - 1)
        {
            return;
        }

        string currentImagePath = imagePaths[currentIndex];
        CurrentImageBitmap = LoadBitmapImage(currentImagePath);

        if (currentImagePath.EndsWith("gif", StringComparison.CurrentCultureIgnoreCase))
        {
            CurrentImageIsAnimated = true;
            return;
        }
        CurrentImageIsAnimated = false;
    }

    private BitmapImage? LoadBitmapImage(string imagePath)
    {
        try
        {
            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(Path.GetFullPath(imagePath), UriKind.Absolute);
            bitmapImage.DecodePixelHeight = (int)_displaySize.Height; // Just assume height for now; too fucking lazy to read whole ass image file just to get dimensions
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return bitmapImage;
        }
        catch
        {
            return null;
        }
    }
}
