using System.Windows;
using System.Windows.Media.Imaging;
using ViewModels.Services;
using ViewModels.UserControls;

namespace ManualTestApp.TestWindows;

/// <summary>
/// Interaction logic for ImageSetDisplayTestWindow.xaml
/// </summary>
public partial class ImageSetDisplayTestWindow : Window
{
    private IImageSetService _imageSetService;

    public ImageSetDisplayTestWindow(IImageSetService imageSetService)
    {
        InitializeComponent();
        _imageSetService = imageSetService;
        this.Loaded += OnLoad;
    }

    public void OnLoad(object sender, EventArgs e)
    {
        Size displaySize = new Size
        {
            Height = this.ActualHeight,
            Width = this.ActualWidth
        };
        ImageSetDisplayElement.DataContext = new ImageSetDisplayVM(displaySize, _imageSetService);
    }
}
