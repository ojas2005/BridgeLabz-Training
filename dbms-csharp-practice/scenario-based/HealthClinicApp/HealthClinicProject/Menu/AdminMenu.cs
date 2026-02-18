using HealthClinic.Exception;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class AdminMenu
    {
        private readonly SpecialtyMenu _specialtyMenu;
        private readonly DoctorManagementMenu _doctorMgmtMenu;
        private readonly AuditMenu _auditMenu;
        private readonly BillingMenu _billingMenu;

        public AdminMenu(SpecialtyMenu specialtyMenu, DoctorManagementMenu doctorMgmtMenu, AuditMenu auditMenu, BillingMenu billingMenu)
        {
            _specialtyMenu = specialtyMenu;
            _doctorMgmtMenu = doctorMgmtMenu;
            _auditMenu = auditMenu;
            _billingMenu = billingMenu;
        }

        public void Start(User user)
        {
            if (user.Role != UserRole.Admin)
                throw new UnauthorizedAppException("Access denied.");

            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Manage Specialties");
                Console.WriteLine("2. Manage Doctors");
                Console.WriteLine("3. Revenue Report");
                Console.WriteLine("4. View Audit Log");
                Console.WriteLine("0. Logout");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": _specialtyMenu.Start(); break;
                        case "2": _doctorMgmtMenu.Start(); break;
                        case "3": _billingMenu.RevenueReport(); break;
                        case "4": _auditMenu.Start(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (healthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
