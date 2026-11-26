using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ViewModels.Services;
using ViewModels.Windows;

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

    private readonly IServiceGroup _serviceGroup;

    public MainWindowVM(IServiceGroup ServiceGroup) : base(ServiceGroup.WindowService)
    {
        _serviceGroup = ServiceGroup;
    }

    [RelayCommand]
    private void AddSourceDirectory()
    {
        string[]? paths = _winService.GetFolders();
        if (paths is null)
        {
            return;
        }

        foreach(string path in paths)
        {
            if (!SourceDirectories.Contains(path))
            {
                SourceDirectories.Add(path);
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanRemoveSourceDirectory))]
    private void RemoveSourceDirectory()
    {
        if (SourceDirectories.Count < 0)
        {
            return;
        }

        SourceDirectories.RemoveAt(SelectedSourceDirectoryIdx);
        SelectedSourceDirectoryIdx = -1;
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
