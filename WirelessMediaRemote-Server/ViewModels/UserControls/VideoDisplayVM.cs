using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;
using ViewModels.Services;

namespace ViewModels.UserControls;

public partial class VideoDisplayVM : ObservableObject
{
    [ObservableProperty]
    private bool _displayActive = false;

    [ObservableProperty]
    private MediaPlayer? _player;

    [ObservableProperty]
    private bool _playerElementLoaded = false;

    private readonly IMediaPlayerService _mediaPlayerService;

    public VideoDisplayVM(IMediaPlayerService mediaPlayerService)
    {
        _mediaPlayerService = mediaPlayerService;
        _mediaPlayerService.PlayerChanged += OnPlayerChanged;

        OnPlayerChanged();
    }

    private void OnPlayerChanged()
    {
        if (_mediaPlayerService.Player is null)
        {
            DisplayActive = false;
            Player = null;
            return;
        }
        DisplayActive = true;
        Player = _mediaPlayerService.Player;
    }

    partial void OnPlayerElementLoadedChanged(bool value)
    {
        if (PlayerElementLoaded)
        {
            _mediaPlayerService.OnMediaPlayerElementLoaded();
        }
        else
        {
            _mediaPlayerService.OnMediaPlayerElementUnloaded();
        }
    }
}
