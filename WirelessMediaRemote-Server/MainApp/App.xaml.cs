using System.Windows;
using Wpf;
using ViewModels;
using ViewModels.Services;

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
    }
}
