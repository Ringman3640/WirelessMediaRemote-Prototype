using System.Windows;
using Wpf;
using ViewModels;
using ViewModels.Services;
using Microsoft.Win32;

namespace MainApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private WindowServicer _windowServicer;

    public App()
    {
        _windowServicer = new();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow mainWindow = new();
        MainWindowVM mainWindowVM = new(_windowServicer);

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

        public string GetFolder()
        {
            OpenFolderDialog dialog = new();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                return dialog.FolderName;
            }
            return "";
        }

        public string[] GetFolders()
        {
            OpenFolderDialog dialog = new();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                return dialog.FolderNames;
            }
            return [];
        }
    }
}
