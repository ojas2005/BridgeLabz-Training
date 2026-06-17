using HealthClinic.Exception;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class ReceptionistMenu
    {
        private readonly PatientMenu _patientMenu;
        private readonly AppointmentMenu _appointmentMenu;
        private readonly BillingMenu _billingMenu;

        public ReceptionistMenu(PatientMenu patientMenu, AppointmentMenu appointmentMenu, BillingMenu billingMenu)
        {
            _patientMenu = patientMenu;
            _appointmentMenu = appointmentMenu;
            _billingMenu = billingMenu;
        }

        public void Start(User user)
        {
            if (user.Role != UserRole.Receptionist)
                throw new UnauthorizedAppException("Access denied.");

            while (true)
            {
                Console.WriteLine("\n--- Receptionist Menu ---");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Appointment Management");
                Console.WriteLine("3. Billing");
                Console.WriteLine("0. Logout");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": _patientMenu.Start(); break;
                        case "2": _appointmentMenu.Start(user); break; // pass user to log changed_by
                        case "3": _billingMenu.Start(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
