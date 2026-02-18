using HealthClinic.Exception;
using HealthClinic.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HealthClinic.UserSecurity
{
    public sealed class AuthService
    {
        // Built in demo credentials for testing
        private readonly Dictionary<string, (string Hash, User User)> _users =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["admin"] = (Sha256("admin123"), new User { UserId = 1, Username = "admin", Role = UserRole.Admin }),
                ["recep"] = (Sha256("rec123"), new User { UserId = 2, Username = "recep", Role = UserRole.Receptionist }),
                ["doctor1"] = (Sha256("doc123"), new User { UserId = 3, Username = "doctor1", Role = UserRole.Doctor, Doctor = 1 }),
            };

        // Authentication
        public User Login(string username, string password)
        {
            if (!_users.TryGetValue(username, out var entry))
                throw new UnauthorizedAppException("Invalid username or password.");

            if (!string.Equals(entry.Hash, Sha256(password), StringComparison.Ordinal))
                throw new UnauthorizedAppException("Invalid username or password.");

            return entry.User;
        }

        // Hash password using SHA256
        private static string Sha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes);
        }
    }
}
