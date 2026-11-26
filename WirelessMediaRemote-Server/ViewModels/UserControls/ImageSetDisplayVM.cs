using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModels.Services;

namespace ViewModels.UserControls;

public partial class ImageSetDisplayVM : ObservableObject
{
    [ObservableProperty]
    private BitmapImage? _currentImageBitmap = null;

    private readonly IImageSetService _imageSetService;

    private readonly Size _displaySize;

    public ImageSetDisplayVM(Size displaySize, IImageSetService imageSetService)
    {
        _displaySize = displaySize;
        _imageSetService = imageSetService;

        _imageSetService.ImagePathsChanged += LoadCurrentImageBitmap;
        _imageSetService.CurrentIndexChanged += LoadCurrentImageBitmap;

        LoadCurrentImageBitmap();
    }

    private void LoadCurrentImageBitmap()
    {
        int currentIndex = _imageSetService.CurrentIndex;
        List<string> imagePaths = _imageSetService.ImagePaths;

        if (currentIndex < 0 || currentIndex > imagePaths.Count - 1)
        {
            return;
        }

        CurrentImageBitmap = LoadBitmapImage(imagePaths[currentIndex]);
    }

    private BitmapImage? LoadBitmapImage(string imagePath)
    {
        try
        {
            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
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
