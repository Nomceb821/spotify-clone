using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpotifyClone
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow();

            playerWindow.Show();

            this.Close();
        }
        //For the eye to show the password
        private bool isPasswordVisible = false;

        private void ShowPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPasswordVisible)
            {
                VisiblePasswordTextBox.Text = PasswordTextBox.Password;

                VisiblePasswordTextBox.Visibility = Visibility.Visible;

                PasswordTextBox.Visibility = Visibility.Collapsed;

                isPasswordVisible = true;
            }
            else
            {
                PasswordTextBox.Password = VisiblePasswordTextBox.Text;

                PasswordTextBox.Visibility = Visibility.Visible;

                VisiblePasswordTextBox.Visibility = Visibility.Collapsed;

                isPasswordVisible = false;
            }
        }
    }
}
