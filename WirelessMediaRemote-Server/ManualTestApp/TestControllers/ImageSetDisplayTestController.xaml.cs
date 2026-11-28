using ManualTestApp.TestServices;
using ManualTestApp.TestWindows;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for ImageSetDisplayTestController.xaml
/// </summary>
public partial class ImageSetDisplayTestController : Window
{
    private ImageSetServicer _imageSetServicer;

    bool runningToEnd = false;

    public ImageSetDisplayTestController()
    {
        InitializeComponent();
        this.Loaded += OnLoad;
        
        string imagesDirectory = "./Resources/Test Images/";
        List<string> imagePaths = Directory.GetFiles(imagesDirectory).ToList();
        _imageSetServicer = new(imagePaths);
    }

    public void OnLoad(object sender, RoutedEventArgs e)
    {
        this.PrevImageButton.Click += (object sender, RoutedEventArgs e) => _imageSetServicer.PrevIdx();
        this.NextImageButton.Click += (object sender, RoutedEventArgs e) => _imageSetServicer.NextIdx();

        this.ClearImageSetButton.Click += (object sender, RoutedEventArgs e) => _imageSetServicer.ImagePaths = null;
        this.ChangeImageSetButton.Click += ChangeImageSet;
        this.RunToEndButton.Click += RunToEnd;

        ImageSetDisplayTestWindow testWindow = new(_imageSetServicer);
        testWindow.Closed += (object? sender, EventArgs e) => this.Close();
        this.Closed += (object? sender, EventArgs e) => testWindow.Close();
        testWindow.Show();
    }

    private void ChangeImageSet(object sender, RoutedEventArgs e)
    {
        OpenFolderDialog dialog = new();
        dialog.Multiselect = false;
        dialog.ShowDialog();
        string newImageSetDirectory = dialog.FolderName;
        List<string> imageSetPaths = Directory.GetFiles(newImageSetDirectory).ToList();
        _imageSetServicer.ImagePaths = imageSetPaths;
    }

    private void RunToEnd(object sender, RoutedEventArgs e)
    {
        if (runningToEnd)
        {
            return;
        }

        runningToEnd = true;

        Task.Run(() =>
        {
            for (int i = 0; i < _imageSetServicer.ImagePaths.Count; ++i)
            {
                _imageSetServicer.CurrentIndex = i;
                Thread.Sleep(100);
                runningToEnd = false;
            }
        });
    }
}
