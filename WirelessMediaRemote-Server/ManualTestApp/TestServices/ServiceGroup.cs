using ViewModels.Services;

namespace ManualTestApp.TestServices;

internal class ServiceGroup : IServiceGroup
{
    public IWindowService WindowService { get; set; }

    public IMediaPlayerService MediaPlayerService { get; set; }

    public IImageSetService ImageSetService { get; set; }
}
