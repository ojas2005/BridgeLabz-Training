using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class AppMenu
    {
        private readonly AuthService _auth;
        private readonly ReceptionistMenu _receptionistMenu;
        private readonly DoctorMenu _doctorMenu;
        private readonly AdminMenu _adminMenu;

        public AppMenu(AuthService auth, ReceptionistMenu receptionistMenu, DoctorMenu doctorMenu, AdminMenu adminMenu)
        {
            _auth = auth;
            _receptionistMenu = receptionistMenu;
            _doctorMenu = doctorMenu;
            _adminMenu = adminMenu;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n=== HealthClinic Login ===");
                Console.Write("Username: ");
                var u = Console.ReadLine() ?? "";
                Console.Write("Password: ");
                var p = Console.ReadLine() ?? "";

                try
                {
                    var user = _auth.Login(u, p);
                    Console.WriteLine($"Logged in: {user}");

                    switch (user.Role)
                    {
                        case UserRole.Receptionist:
                            _receptionistMenu.Start(user);
                            break;
                        case UserRole.Doctor:
                            _doctorMenu.Start(user);
                            break;
                        case UserRole.Admin:
                            _adminMenu.Start(user);
                            break;
                    }
                }
                catch (healthClinicException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}
