using SpotifyClone.Services;
using System.Windows;

namespace SpotifyClone
{
    public partial class AuthWindow : Window
    {
        private readonly AuthService authService =
            new AuthService();

        private readonly SessionService sessionService =
            new SessionService();

        public AuthWindow()
        {
            InitializeComponent();
        }

        // LOGIN
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;

            string password;

            // CHECK VISIBLE PASSWORD
            if (VisiblePasswordTextBox.Visibility == Visibility.Visible)
            {
                password = VisiblePasswordTextBox.Text;
            }
            else
            {
                password = PasswordTextBox.Password;
            }

            bool success =
                authService.Login(email, password);

            if (success)
            {
                if (RememberMeCheckBox.IsChecked == true)
                {
                    sessionService.SaveSession(email);
                }

                MessageBox.Show("Login successful!");

                PlayerWindow playerWindow = new PlayerWindow();

                playerWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        // SIGN UP
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow =
                new RegisterWindow();

            registerWindow.Show();

            this.Close();
        }

        // SHOW PASSWORD
        private bool isPasswordVisible = false;

        private void ShowPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPasswordVisible)
            {
                VisiblePasswordTextBox.Text =
                    PasswordTextBox.Password;

                VisiblePasswordTextBox.Visibility =
                    Visibility.Visible;

                PasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isPasswordVisible = true;
            }
            else
            {
                PasswordTextBox.Password =
                    VisiblePasswordTextBox.Text;

                PasswordTextBox.Visibility =
                    Visibility.Visible;

                VisiblePasswordTextBox.Visibility =
                    Visibility.Collapsed;

                isPasswordVisible = false;
            }

        }
        private void ForgotPassword_Click(object sender,
                                  System.Windows.Input.MouseButtonEventArgs e)
        {
            ResetPasswordWindow resetWindow =
                new ResetPasswordWindow();

            resetWindow.Show();

            this.Close();
        }
    }
}