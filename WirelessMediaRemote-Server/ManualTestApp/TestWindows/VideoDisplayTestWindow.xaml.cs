using System.Windows;
using ViewModels.Services;
using ViewModels.UserControls;

namespace ManualTestApp.TestWindows;

/// <summary>
/// Interaction logic for VideoDisplayTestWindow.xaml
/// </summary>
public partial class VideoDisplayTestWindow : Window
{
    public VideoDisplayTestWindow(IMediaPlayerService playerService)
    {
        InitializeComponent();
        this.VideoDisplayElement.DataContext = new VideoDisplayVM(playerService);
    }
}
