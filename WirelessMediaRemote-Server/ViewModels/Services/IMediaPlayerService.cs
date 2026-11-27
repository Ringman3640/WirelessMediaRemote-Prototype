using LibVLCSharp.Shared;

namespace ViewModels.Services;

public interface IMediaPlayerService
{
    public MediaPlayer Player { get; }
}
