using LibVLCSharp.Shared;

namespace ViewModels.Services;

public interface IMediaPlayerService
{
    public MediaPlayer? Player { get; }

    public void OnMediaPlayerElementLoaded();

    public void OnMediaPlayerElementUnloaded();

    public event Action? PlayerChanged;
}
