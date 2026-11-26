using System.Windows;
using Wpf.Windows;
using ViewModels;
using ViewModels.Services;
using Microsoft.Win32;
using ViewModels.Windows;

namespace MainApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, IServiceGroup
{
    public IWindowService WindowService { get; }

    public App()
    {
        WindowService = new WindowServicer();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow mainWindow = new();
        MainWindowVM mainWindowVM = new(this);

        mainWindow.DataContext = mainWindowVM;
        mainWindow.Show();
    }

    private class WindowServicer : IWindowService
    {
        public void ShowWindow(BaseWindowVM windowVM)
        {
            throw new NotImplementedException();
        }

        public void CloseWindow(BaseWindowVM windowVM)
        {
            throw new NotImplementedException();
        }

        public string? GetFolder()
        {
            OpenFolderDialog dialog = new();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                return dialog.FolderName;
            }
            return null;
        }

        public string[]? GetFolders()
        {
            OpenFolderDialog dialog = new();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                return dialog.FolderNames;
            }
            return null;
        }
    }
}
