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
                if (value is null)
                {
                    _player?.Stop();
                }
                _player = value;
                PlayerChanged?.Invoke();
            }
        }
    }
    private MediaPlayer? _player;

    public event Action? PlayerChanged;

    private LibVLC _vlc;

    private bool _playerElementLoaded = false;

    private bool _playOnLoaded = false;

    public MediaPlayerServicer()
    {
        _vlc = new LibVLC();
        Player = new MediaPlayer(_vlc);
    }

    public void Play(string videoPath)
    {
        Player?.Media = new Media(_vlc, videoPath, FromType.FromPath);
        if (!_playerElementLoaded)
        {
            _playOnLoaded = true;
            return;
        }
        Player?.Play();
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
        if (_playOnLoaded)
        {
            _player?.Play();
            _playOnLoaded = false;
        }
    }

    public void OnMediaPlayerElementUnloaded()
    {
        _playerElementLoaded = false;
        Player!.Stop();
    }
}