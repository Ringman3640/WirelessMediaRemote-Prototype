namespace ViewModels.Services;

public interface IServiceGroup
{
    IWindowService WindowService { get; }

    IMediaPlayerService MediaPlayerService { get; }

    IImageSetService ImageSetService { get; }
}
