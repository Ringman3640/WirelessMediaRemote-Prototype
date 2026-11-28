using ViewModels.Services;

namespace ViewModels.Windows;

public partial class MediaWindowVM : BaseWindowVM
{
    private IServiceGroup _serviceGroup;

    public MediaWindowVM(IServiceGroup serviceGroup) : base(serviceGroup.WindowService)
    {
        _serviceGroup = serviceGroup;
    }
}
