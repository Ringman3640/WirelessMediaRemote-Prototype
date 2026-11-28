using LibVLCSharp.Shared;
using ManualTestApp.TestServices;
using ManualTestApp.TestWindows;
using System.Windows;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for VideoDisplayTestController.xaml
/// </summary>
public partial class VideoDisplayTestController : Window
{
    private MediaPlayerServicer _playerServicer;

    public VideoDisplayTestController()
    {
        InitializeComponent();
        this.Loaded += OnLoad;

        string startVideoPath = "./Resources/Test Videos/video1.mp4";
        _playerServicer = new MediaPlayerServicer(startVideoPath);
    }

    public void OnLoad(object sender, RoutedEventArgs e)
    {
        this.ChangeVideo.Click += (object sender, RoutedEventArgs e) => _playerServicer.OpenVideo();
        this.VideoSlider.ValueChanged += SliderValueChagned;

        VideoDisplayTestWindow testWindow = new(_playerServicer);
        this.Closed += (object? sender, EventArgs e) => testWindow.Close();
        testWindow.Closed += (object? sender, EventArgs e) => this.Close();
        testWindow.Show();
    }

    private void SliderValueChagned(object sender, RoutedEventArgs e)
    {
        var slider = this.VideoSlider;
        double sliderPercent = slider.Value / slider.Maximum;

        MediaPlayer? player = _playerServicer.Player;
        player?.Time = (long)(player.Length * sliderPercent);
    }
}
