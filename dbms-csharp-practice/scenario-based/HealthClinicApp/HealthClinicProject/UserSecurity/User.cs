using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HealthClinic.UserSecurity
{
    public sealed class User
    {
        // User identification
        public int UserId { get; init; }
        public string Username { get; init; } = "";
        
        // Role and relation
        public UserRole Role { get; init; }
        public int? Doctor { get; init; }

        public override string ToString() => $"{Username} ({Role})";
    }
}
