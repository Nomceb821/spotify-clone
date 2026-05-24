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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly AuthService authService =
            new AuthService();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        // CREATE ACCOUNT
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string email =
                RegisterEmailTextBox.Text;

            string password;

            string confirmPassword;

            // PASSWORD
            if (VisibleRegisterPasswordTextBox.Visibility == Visibility.Visible)
            {
                password =
                    VisibleRegisterPasswordTextBox.Text;
            }
            else
            {
                password =
                    RegisterPasswordTextBox.Password;
            }

            // CONFIRM PASSWORD
            if (VisibleConfirmPasswordTextBox.Visibility == Visibility.Visible)
            {
                confirmPassword =
                    VisibleConfirmPasswordTextBox.Text;
            }
            else
            {
                confirmPassword =
                    ConfirmPasswordTextBox.Password;
            }

            // EMPTY FIELDS
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");

                return;
            }

            // PASSWORD MATCH
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");

                return;
            }

            // REGISTER USER
            // VALID EMAIL
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email.");

                return;
            }

            // STRONG PASSWORD
            if (password.Length < 8 ||
                !password.Any(char.IsUpper) ||
                !password.Any(char.IsLower) ||
                !password.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "Password must contain:\n" +
                    "- 8 characters\n" +
                    "- uppercase letter\n" +
                    "- lowercase letter\n" +
                    "- number");

                return;
            }

            // REGISTER USER
            bool success =
                authService.Register(email, password);

            if (success)
            {
                MessageBox.Show("Account created successfully!");

                AuthWindow authWindow =
                    new AuthWindow();

                authWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Email already exists.");
            }
        }

        // SHOW PASSWORD
        private bool isRegisterPasswordVisible = false;

        private void ShowRegisterPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRegisterPasswordVisible)
            {
                VisibleRegisterPasswordTextBox.Text =
                    RegisterPasswordTextBox.Password;

                VisibleRegisterPasswordTextBox.Visibility =
                    Visibility.Visible;

                RegisterPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isRegisterPasswordVisible = true;
            }
            else
            {
                RegisterPasswordTextBox.Password =
                    VisibleRegisterPasswordTextBox.Text;

                RegisterPasswordTextBox.Visibility =
                    Visibility.Visible;

                VisibleRegisterPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isRegisterPasswordVisible = false;
            }
        }

        // SHOW CONFIRM PASSWORD
        private bool isConfirmPasswordVisible = false;

        private void ShowConfirmPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isConfirmPasswordVisible)
            {
                VisibleConfirmPasswordTextBox.Text =
                    ConfirmPasswordTextBox.Password;

                VisibleConfirmPasswordTextBox.Visibility =
                    Visibility.Visible;

                ConfirmPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isConfirmPasswordVisible = true;
            }
            else
            {
                ConfirmPasswordTextBox.Password =
                    VisibleConfirmPasswordTextBox.Text;

                ConfirmPasswordTextBox.Visibility =
                    Visibility.Visible;

                VisibleConfirmPasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isConfirmPasswordVisible = false;
            }
        }
    }
}
