using LibVLCSharp.Shared;
using ManualTestApp.TestServices;
using System.IO;
using System.Windows;
using ViewModels.Services;
using ViewModels.Windows;
using Wpf.Windows;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for MediaWindowTestController.xaml
/// </summary>
public partial class MediaWindowTestController : Window
{
    private ServiceGroup _serviceGroup;

    private bool _displayingImage = true;

    private readonly List<string> _imageSetResourcePaths;

    private readonly string _videoResourcePath;

    private MediaPlayerServicer _mediaPlayerServicer;

    private ImageSetServicer _imageSetServicer;

    private MediaPlayer _mediaPlayer;

    public MediaWindowTestController()
    {
        InitializeComponent();
        this.Loaded += OnLoad;

        _videoResourcePath = "./Resources/Test Videos/video1.mp4";
        _imageSetResourcePaths = Directory.GetFiles("./Resources/Test Images").ToList();

        _mediaPlayerServicer = new MediaPlayerServicer();
        _imageSetServicer = new ImageSetServicer(_imageSetResourcePaths);

        _serviceGroup = new ServiceGroup()
        {
            WindowService = new WindowServicer(),
            MediaPlayerService = _mediaPlayerServicer,
            ImageSetService = _imageSetServicer
        };

        _mediaPlayer = new MediaPlayer(new LibVLC());
    }

    public void OnLoad(object sender, RoutedEventArgs e)
    {
        this.SwitchToImageSetButton.Click += OnSwitchToImageSet;
        this.NextImageButton.Click += OnNextImage;
        this.PrevImageButton.Click += OnPrevImage;
        this.SwitchToVideoButton.Click += OnSwitchToVideo;
        this.VideoSlider.ValueChanged += VideoSliderValueChagned;

        MediaWindow mediaWindow = new();
        mediaWindow.DataContext = new MediaWindowVM(_serviceGroup);
        this.Closed += (object? sender, EventArgs e) => mediaWindow.Close();
        mediaWindow.Closed += (object? sender, EventArgs e) => this.Close();
        mediaWindow.Show();
    }

    private void OnSwitchToImageSet(object sender, RoutedEventArgs e)
    {
        if (_displayingImage)
        {
            return;
        }
        _displayingImage = true;

        _mediaPlayerServicer.Player = null;
        _imageSetServicer.ImagePaths = _imageSetResourcePaths;
        _imageSetServicer.CurrentIndex = 0;
    }

    private void OnNextImage(object sender, RoutedEventArgs e)
    {
        if (!_displayingImage)
        {
            return;
        }

        _imageSetServicer.NextIdx();
    }

    private void OnPrevImage(object sender, RoutedEventArgs e)
    {
        if (!_displayingImage)
        {
            return;
        }

        _imageSetServicer.PrevIdx();
    }

    private void OnSwitchToVideo(object sender, RoutedEventArgs e)
    {
        if (!_displayingImage)
        {
            return;
        }
        _displayingImage = false;

        _imageSetServicer.ImagePaths = null;
        _mediaPlayerServicer.Player = _mediaPlayer;
        _mediaPlayerServicer.Play(_videoResourcePath);
    }

    private void VideoSliderValueChagned(object sender, RoutedEventArgs e)
    {
        if (_displayingImage == true)
        {
            return;
        }
        var slider = this.VideoSlider;
        double sliderPercent = slider.Value / slider.Maximum;

        MediaPlayer player = _serviceGroup.MediaPlayerService.Player!;
        player.Time = (long)(player.Length * sliderPercent);
    }
}
