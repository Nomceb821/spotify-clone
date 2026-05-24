using SpotifyClone.Services;
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
    /// Interaction logic for ResetPasswordWindow.xaml
    /// </summary>
    public partial class ResetPasswordWindow : Window
    {
        private readonly AuthService authService =
            new AuthService();

        public ResetPasswordWindow()
        {
            InitializeComponent();
        }

        // RESET PASSWORD
        private void ResetPasswordButton_Click(object sender,
                                               RoutedEventArgs e)
        {
            string email =
                EmailTextBox.Text;

            string newPassword;

            // CHECK VISIBLE PASSWORD
            if (VisibleNewPasswordTextBox.Visibility == Visibility.Visible)
            {
                newPassword =
                    VisibleNewPasswordTextBox.Text;
            }
            else
            {
                newPassword =
                    NewPasswordTextBox.Password;
            }

            bool success =
                authService.ResetPassword(
                    email,
                    newPassword);

            if (success)
            {
                MessageBox.Show(
                    "Password reset successful!");

                AuthWindow authWindow =
                    new AuthWindow();

                authWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Email not found.");
            }
        }

        // SHOW PASSWORD
        private bool isPasswordVisible = false;

        private void ShowPasswordButton_Click(object sender,
                                              RoutedEventArgs e)
        {
            if (!isPasswordVisible)
            {
                VisibleNewPasswordTextBox.Text =
                    NewPasswordTextBox.Password;

                VisibleNewPasswordTextBox.Visibility =
                    Visibility.Visible;

                NewPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isPasswordVisible = true;
            }
            else
            {
                NewPasswordTextBox.Password =
                    VisibleNewPasswordTextBox.Text;

                NewPasswordTextBox.Visibility =
                    Visibility.Visible;

                VisibleNewPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isPasswordVisible = false;
            }
        }
    }
}
