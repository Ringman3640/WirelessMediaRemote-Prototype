using CommunityToolkit.Mvvm.ComponentModel;
using LibVLCSharp.Shared;
using ViewModels.Services;

namespace ViewModels.UserControls;

public partial class VideoDisplayVM : ObservableObject
{
    [ObservableProperty]
    private MediaPlayer _player;

    private IMediaPlayerService _mediaPlayerService;

    public VideoDisplayVM(IMediaPlayerService mediaPlayerService)
    {
        Player = mediaPlayerService.Player;
        _mediaPlayerService = mediaPlayerService;
    }
}
