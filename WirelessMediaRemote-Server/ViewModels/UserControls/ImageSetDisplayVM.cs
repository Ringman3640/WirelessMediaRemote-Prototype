using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using ViewModels.Services;

namespace ViewModels.UserControls;

public class ImageSetDisplayVM : ObservableObject
{
    public Size DisplaySize { get; set; }

    private IImageSetService _imageSetService;

    public ImageSetDisplayVM(Size displaySize, IImageSetService imageSetService)
    {
        DisplaySize = displaySize;
        _imageSetService = imageSetService;
    }
}
