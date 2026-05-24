using SpotifyClone.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SpotifyClone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SessionService sessionService =
                new SessionService();

            string savedUser =
                sessionService.GetSavedSession();

            // IF USER IS REMEMBERED
            if (savedUser != null)
            {
                MainWindow mainWindow =
                    new MainWindow();

                mainWindow.Show();
            }
            else
            {
                AuthWindow authWindow =
                    new AuthWindow();

                authWindow.Show();
            }
        }
    }

}
