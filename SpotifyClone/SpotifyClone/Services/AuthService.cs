using SpotifyClone.Data;
using SpotifyClone.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SpotifyClone.Services
{
    public class AuthService
    {
        private readonly SpotifyDbContext context =
            new SpotifyDbContext();

        // REGISTER USER
        public bool Register(string email, string password)
        {
            // CLEAN EMAIL
            email = email.Trim().ToLower();

            // VALIDATE EMAIL
            if (!IsValidEmail(email))
            {
                return false;
            }

            // VALIDATE PASSWORD
            if (!IsStrongPassword(password))
            {
                return false;
            }

            // CHECK IF EMAIL EXISTS
            bool userExists =
                context.Users.Any(u =>
                    u.Email.ToLower() == email);

            if (userExists)
            {
                return false;
            }

            User user = new User
            {
                Email = email,

                // SAVE HASHED PASSWORD
                Password = HashPassword(password)
            };

            context.Users.Add(user);

            context.SaveChanges();

            return true;
        }

        // LOGIN USER
        public bool Login(string email, string password)
        {
            // HASH ENTERED PASSWORD
            string hashedPassword =
                HashPassword(password);

            return context.Users.Any(u =>
                u.Email == email &&
                u.Password == hashedPassword);
        }

        // HASH PASSWORD
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes =
                    sha256.ComputeHash(
                        Encoding.UTF8.GetBytes(password));

                StringBuilder builder =
                    new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // VALIDATE EMAIL
        private bool IsValidEmail(string email)
        {
            string pattern =
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        // VALIDATE PASSWORD
        private bool IsStrongPassword(string password)
        {
            return password.Length >= 8
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsLower)
                   && password.Any(char.IsDigit);
        }

        public bool ResetPassword(string email,
                          string newPassword)
        {
            email = email.Trim().ToLower();

            User user =
                context.Users.FirstOrDefault(u =>
                    u.Email.ToLower() == email);

            if (user == null)
            {
                return false;
            }

            user.Password =
                HashPassword(newPassword);

            context.SaveChanges();

            return true;
        }
    }
}