using LibVLCSharp.Shared;
using Microsoft.Win32;
using ViewModels.Services;

namespace ManualTestApp.TestServices;

internal class MediaPlayerServicer : IMediaPlayerService
{
    public MediaPlayer? Player
    {
        get { return _player; }
        set
        {
            if (value != _player)
            {
                _player = value;
                PlayerChanged?.Invoke();
            }
        }
    }
    private MediaPlayer? _player;

    public event Action? PlayerChanged;

    private LibVLC _vlc;

    private bool _playerElementLoaded = false;

    public MediaPlayerServicer(string startVideoPath)
    {
        _vlc = new LibVLC();
        Player = new MediaPlayer(_vlc);
        using Media media = new(_vlc, startVideoPath, FromType.FromPath);
        Player.Media = media;
    }

    public void OpenVideo()
    {
        OpenFileDialog dialog = new()
        {
            Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.wmv|All files|*.*"
        };

        if (dialog.ShowDialog() == true)
        {
            using Media media = new(_vlc, dialog.FileName, FromType.FromPath);
            Player!.Media = media;
            if (_playerElementLoaded)
            {
                Player!.Play();
            }
        }
    }

    public void OnMediaPlayerElementLoaded()
    {
        _playerElementLoaded = true;
        Player!.Play();
    }

    public void OnMediaPlayerElementUnloaded()
    {
        _playerElementLoaded = false;
        Player!.Stop();
    }
}