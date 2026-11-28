using CommunityToolkit.Mvvm.ComponentModel;
using ViewModels.Services;
using ViewModels.UserControls;

namespace ViewModels.Windows;

public partial class MediaWindowVM : BaseWindowVM
{
    [ObservableProperty]
    private ImageSetDisplayVM _imageSetDisplayDataContext;

    [ObservableProperty]
    private VideoDisplayVM _videoDisplayDataContext;

    private IServiceGroup _serviceGroup;

    public MediaWindowVM(IServiceGroup serviceGroup) : base(serviceGroup.WindowService)
    {
        _serviceGroup = serviceGroup;
        ImageSetDisplayDataContext = new ImageSetDisplayVM(_serviceGroup.ImageSetService);
        VideoDisplayDataContext = new VideoDisplayVM(_serviceGroup.MediaPlayerService);
    }
}
