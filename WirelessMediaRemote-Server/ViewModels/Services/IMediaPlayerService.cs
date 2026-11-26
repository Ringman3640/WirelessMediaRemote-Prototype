using System.Windows.Media;

namespace ViewModels.Services;

internal interface IMediaPlayerService
{
    public MediaPlayer Player { get; }
}
