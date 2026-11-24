using ViewModels.Services;

namespace ViewModels;

public partial class MainWindowVM : BaseWindowVM
{
    public MainWindowVM(IWindowService winService) : base(winService)
    {
    }
}
