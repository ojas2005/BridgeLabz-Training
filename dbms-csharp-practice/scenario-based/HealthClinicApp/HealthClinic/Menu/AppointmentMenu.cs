using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class AppointmentMenu
    {
        private readonly IAppointmentUtility _util;

        public AppointmentMenu(IAppointmentUtility util) => _util = util;

        // ACTION BOOK
        private void Book()
        {
            var a = new Appointment();
            Console.Write("Patient ID: "); a.PatientId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Doctor ID: "); a.DoctorId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Date (yyyy-mm-dd): "); a.AppointmentDate = DateTime.Parse(Console.ReadLine() ?? "").Date;
            Console.Write("Time (HH:mm): "); a.AppointmentTime = TimeSpan.Parse(Console.ReadLine() ?? "00:00");

            _util.Book(a);
            Console.WriteLine("Appointment booked.");
        }

        // ACTION CANCEL
        private void Cancel(User user)
        {
            Console.Write("Appointment ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Reason (optional): ");
            var reason = Console.ReadLine();

            _util.Cancel(id, string.IsNullOrWhiteSpace(reason) ? null : reason.Trim(), user.Username);
            Console.WriteLine("Appointment cancelled.");
        }

        // ACTION RESCHEDULE
        private void Reschedule(User user)
        {
            Console.Write("Appointment ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("New Date (yyyy-mm-dd): ");
            var nd = DateTime.Parse(Console.ReadLine() ?? "").Date;
            Console.Write("New Time (HH:mm): ");
            var nt = TimeSpan.Parse(Console.ReadLine() ?? "00:00");
            Console.Write("New Doctor ID (optional, blank to keep same): ");
            var docText = Console.ReadLine();
            int? newDoc = string.IsNullOrWhiteSpace(docText) ? null : int.Parse(docText);

            Console.Write("Reason (optional): ");
            var reason = Console.ReadLine();

            _util.Reschedule(id, nd, nt, newDoc, string.IsNullOrWhiteSpace(reason) ? null : reason.Trim(), user.Username);
            Console.WriteLine("Appointment rescheduled.");
        }

        // ACTION AVAILABILITY
        private void Availability()
        {
            Console.Write("Doctor ID: ");
            var docId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Date (yyyy-mm-dd): ");
            var d = DateTime.Parse(Console.ReadLine() ?? "").Date;

            var lines = _util.DoctorAvailabilityLines(docId, d);
            if (lines.Count == 0) { Console.WriteLine("No bookings."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }

        // HELPER DISPLAY
        public void ViewDailySchedule()
        {
            Console.Write("Date (yyyy-mm-dd): ");
            var d = DateTime.Parse(Console.ReadLine() ?? "");
            var lines = _util.DailyScheduleLines(d);
            if (lines.Count == 0) { Console.WriteLine("No appointments."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }

        // MAIN MENU LOOP
        public void Start(User user)
        {
            while (true)
            {
                Console.WriteLine("\n--- Appointment Menu ---");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. Reschedule Appointment");
                Console.WriteLine("4. Check Doctor Availability");
                Console.WriteLine("5. View Daily Schedule");
                Console.WriteLine("0. Back");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": Book(); break;
                        case "2": Cancel(user); break;
                        case "3": Reschedule(user); break;
                        case "4": Availability(); break;
                        case "5": ViewDailySchedule(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
