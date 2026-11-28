using ManualTestApp.TestControllers;
using System.Windows;

namespace ManualTestApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ImageSetDisplayTestButton.Click += (object sender, RoutedEventArgs e) =>
        {
            new ImageSetDisplayTestController().ShowDialog();
        };

        VideoDisplayTestButton.Click += (object sender, RoutedEventArgs e) =>
        {
            new VideoDisplayTestController().ShowDialog();
        };

        MediaWindowTestButton.Click += (object sender, RoutedEventArgs e) =>
        {
            new MediaWindowTestController().ShowDialog();
        };
    }
}
