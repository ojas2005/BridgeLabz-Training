using HealthClinic.Exception;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class DoctorMenu
    {
        private readonly AppointmentMenu _appointmentMenu;
        private readonly VisitPrescriptionMenu _visitRxMenu;

        public DoctorMenu(AppointmentMenu appointmentMenu, VisitPrescriptionMenu visitRxMenu)
        {
            _appointmentMenu = appointmentMenu;
            _visitRxMenu = visitRxMenu;
        }

        // HELPER AUTHORIZATION
        private void AuthorizeDoctor(User user)
        {
            if (user.Role != UserRole.Doctor)
                throw new UnauthorizedAppException("Access denied.");
        }

        // MAIN MENU LOOP
        public void Start(User user)
        {
            AuthorizeDoctor(user);

            while (true)
            {
                Console.WriteLine("\n--- Doctor Menu ---");
                Console.WriteLine("1. View Daily Schedule");
                Console.WriteLine("2. Visits & Prescriptions");
                Console.WriteLine("0. Logout");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1":
                            _appointmentMenu.ViewDailySchedule();
                            break;
                        case "2":
                            _visitRxMenu.Start(user);
                            break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (healthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
