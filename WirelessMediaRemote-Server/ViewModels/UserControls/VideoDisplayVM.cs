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

    private readonly IMediaPlayerService _mediaPlayerService;

    public VideoDisplayVM(IMediaPlayerService mediaPlayerService)
    {
        _mediaPlayerService = mediaPlayerService;
        _mediaPlayerService.PlayerChanged += OnPlayerChanged;

        OnPlayerChanged();
    }

    [RelayCommand]
    private void PlayerElementLoaded()
    {
        _mediaPlayerService.OnMediaPlayerElementLoaded();
    }

    [RelayCommand]
    public void PlayerElementUnloaded()
    {
        _mediaPlayerService.OnMediaPlayerElementUnloaded();
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

}
