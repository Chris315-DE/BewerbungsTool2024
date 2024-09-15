#define LoadManagerTests
using BewerbungsTool.Manager;
using BewerbungsTool.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BewerbungsTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {




            MainWindow window = new MainWindow();

            window.DataContext = new MainWindowViewModel(window);
            window.Show();

            base.OnStartup(e);
        }

    }

}
