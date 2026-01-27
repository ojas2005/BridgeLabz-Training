using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserRegistration
    {
        public void RegisterUser(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Invalid password");
        }
    }
}
