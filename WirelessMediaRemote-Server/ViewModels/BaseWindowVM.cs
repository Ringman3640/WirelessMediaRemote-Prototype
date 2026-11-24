using CommunityToolkit.Mvvm.ComponentModel;
using ViewModels.Services;

namespace ViewModels;

public abstract partial class BaseWindowVM : ObservableObject
{
    protected IWindowService _winService;

    protected BaseWindowVM(IWindowService winService)
    {
        _winService = winService;
    }
}
