using ManualTestApp.TestServices;
using System.Windows;
using ViewModels.Windows;
using Wpf.Windows;

namespace ManualTestApp.TestControllers;

/// <summary>
/// Interaction logic for MediaWindowTestController.xaml
/// </summary>
public partial class MediaWindowTestController : Window
{
    ServiceGroup _serviceGroup;

    public MediaWindowTestController()
    {
        InitializeComponent();
        this.Loaded += OnLoad;

        _serviceGroup = new ServiceGroup()
        {
            WindowService = new WindowServicer()
        };
    }

    public void OnLoad(object sender, RoutedEventArgs e)
    {
        //this.ChangeVideo.Click += (object sender, RoutedEventArgs e) => _playerServicer.OpenVideo();
        //this.VideoSlider.ValueChanged += SliderValueChagned;

        MediaWindow mediaWindow = new();
        mediaWindow.DataContext = new MediaWindowVM(_serviceGroup);
        this.Closed += (object? sender, EventArgs e) => mediaWindow.Close();
        mediaWindow.Closed += (object? sender, EventArgs e) => this.Close();
        mediaWindow.Show();
    }
}
