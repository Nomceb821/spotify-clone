using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // NAVIGATE TO PLAYER WINDOW
        private void GetSpotifyButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();

            authWindow.Show();

            this.Close();
        }
        // Login onclick
        private void LoginNavButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow =
                new AuthWindow();

            authWindow.Show();

            this.Close();
        }
    }
}