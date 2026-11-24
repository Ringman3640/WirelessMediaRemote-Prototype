using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ViewModels.Services;

namespace ViewModels;

public partial class MainWindowVM : BaseWindowVM
{
    [ObservableProperty]
    private ObservableCollection<string> _sourceDirectories = [];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemoveSourceDirectoryCommand))]
    private int _selectedSourceDirectoryIdx = -1;

    [ObservableProperty]
    private bool _serverListening = false;

    public MainWindowVM(IWindowService winService) : base(winService)
    {
    }

    [RelayCommand]
    private void AddSourceDirectory()
    {
        throw new NotImplementedException();
    }

    [RelayCommand(CanExecute = nameof(CanRemoveSourceDirectory))]
    private void RemoveSourceDirectory()
    {
        throw new NotImplementedException();
    }
    private bool CanRemoveSourceDirectory()
    {
        return SelectedSourceDirectoryIdx >= 0;
    }

    [RelayCommand]
    private void ToggleServerListeningState()
    {
        ServerListening = !ServerListening;
    }
}
