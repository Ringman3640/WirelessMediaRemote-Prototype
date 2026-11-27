using LibVLCSharp.Shared;
using ManualTestApp.TestWindows;
using Microsoft.Win32;
using System.Windows;
using ViewModels.Services;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for VideoDisplayTestController.xaml
/// </summary>
public partial class VideoDisplayTestController : Window
{
    private MediaPlayerService _playerServicer;

    public VideoDisplayTestController()
    {
        InitializeComponent();
        this.Loaded += OnLoad;

        string startVideoPath = "./Resources/Test Videos/video1.mp4";
        _playerServicer = new MediaPlayerService(startVideoPath);
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

        MediaPlayer player = _playerServicer.Player;
        player.Time = (long)(player.Length * sliderPercent);
    }

    private class MediaPlayerService : IMediaPlayerService
    {
        public MediaPlayer Player { get; }

        private LibVLC vlc;

        public MediaPlayerService(string startVideoPath)
        {
            vlc = new LibVLC();
            Player = new MediaPlayer(vlc);
            SetVideo(startVideoPath);
        }

        public void OpenVideo()
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.wmv|All files|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                SetVideo(dialog.FileName);
            }
        }

        private void SetVideo(string videoPath)
        {
            using Media newMedia = new(vlc!, videoPath, FromType.FromPath);
            Player!.Play(newMedia);
        }
    }
}
