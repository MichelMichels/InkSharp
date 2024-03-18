using System.Windows;

namespace MichelMichels.InkSharp.Demo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var view = new MainWindow()
        {
            DataContext = new MainViewModel()
        };
        view.ShowDialog();
    }
}
