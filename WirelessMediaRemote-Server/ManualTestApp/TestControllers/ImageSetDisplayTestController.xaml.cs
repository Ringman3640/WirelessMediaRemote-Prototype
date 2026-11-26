using ManualTestApp.TestWindows;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModels.Services;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for ImageSetDisplayTestController.xaml
/// </summary>
public partial class ImageSetDisplayTestController : Window
{
    public ImageSetDisplayTestController()
    {
        InitializeComponent();

        this.Loaded += OnLoad;
    }

    public void OnLoad(object sender, RoutedEventArgs e)
    {
        string imagesDirectory = "./Resources/Test Images/";
        List<string> imagePaths = Directory.GetFiles(imagesDirectory).ToList();
        ImageSetServicer imageSetServicer = new(imagePaths);

        this.PrevImageButton.Click += (object sender, RoutedEventArgs e) => imageSetServicer.CurrentIndex = Math.Max(0, imageSetServicer.CurrentIndex - 1);
        this.NextImageButton.Click += (object sender, RoutedEventArgs e) => imageSetServicer.CurrentIndex = Math.Min(imagePaths.Count - 1, imageSetServicer.CurrentIndex + 1);

        ImageSetDisplayTestWindow testWindow = new(imageSetServicer);
        testWindow.Closed += (object? sender, EventArgs e) => this.Close();
        this.Closed += (object? sender, EventArgs e) => testWindow.Close();
        testWindow.Show();
    }

    private class ImageSetServicer : IImageSetService
    {
        public List<string> ImagePaths { get; }

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                if (value != _currentIndex)
                {
                    _currentIndex = value;
                    CurrentIndexChanged?.Invoke(value);
                }
            }
        }

        private int _currentIndex = 0;
        public event IImageSetService.OnCurrentIndexChanged? CurrentIndexChanged = null;

        public ImageSetServicer(List<string> imagePaths)
        {
            ImagePaths = imagePaths;
        }
    }
}
