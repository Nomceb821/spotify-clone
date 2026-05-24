using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotifyClone.Services
{
    public class SessionService
    {
        private readonly string sessionFile =
            "session.txt";

        // SAVE USER SESSION
        public void SaveSession(string email)
        {
            File.WriteAllText(sessionFile, email);
        }

        // GET SAVED USER
        public string GetSavedSession()
        {
            if (File.Exists(sessionFile))
            {
                return File.ReadAllText(sessionFile);
            }

            return null;
        }

        // CLEAR SESSION
        public void ClearSession()
        {
            if (File.Exists(sessionFile))
            {
                File.Delete(sessionFile);
            }
        }
    }
}