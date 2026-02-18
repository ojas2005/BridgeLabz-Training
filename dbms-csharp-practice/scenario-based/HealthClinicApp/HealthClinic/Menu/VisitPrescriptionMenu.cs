using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.UserSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class VisitPrescriptionMenu
    {
        private readonly IVisitUtility _visitUtil;
        private readonly IPrescriptionUtility _rxUtil;

        public VisitPrescriptionMenu(IVisitUtility visitUtil, IPrescriptionUtility rxUtil)
        {
            _visitUtil = visitUtil;
            _rxUtil = rxUtil;
        }

        public void Start(User user)
        {
            while (true)
            {
                Console.WriteLine("\n--- Visits & Prescriptions ---");
                Console.WriteLine("1. Record Visit");
                Console.WriteLine("2. Add Prescription");
                Console.WriteLine("3. View Patient Medical History");
                Console.WriteLine("0. Back");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": RecordVisit(); break;
                        case "2": AddRx(); break;
                        case "3": History(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }

        private void RecordVisit()
        {
            Console.Write("Appointment ID: ");
            var apptId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Diagnosis: ");
            var diag = Console.ReadLine() ?? "";
            Console.Write("Notes (optional): ");
            var notes = Console.ReadLine();

            _visitUtil.RecordVisit(apptId, diag, string.IsNullOrWhiteSpace(notes) ? null : notes.Trim());
            Console.WriteLine("Visit recorded (appointment set to COMPLETED).");
        }

        private void AddRx()
        {
            Console.Write("Visit ID: ");
            var visitId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Medicine: ");
            var med = Console.ReadLine() ?? "";
            Console.Write("Dosage: ");
            var dose = Console.ReadLine() ?? "";
            Console.Write("Duration days: ");
            var days = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Instructions (optional): ");
            var ins = Console.ReadLine();

            _rxUtil.AddPrescription(visitId, med, dose, days, string.IsNullOrWhiteSpace(ins) ? null : ins.Trim());
            Console.WriteLine("Prescription added.");
        }

        private void History()
        {
            Console.Write("Patient ID: ");
            var pid = int.Parse(Console.ReadLine() ?? "0");
            var lines = _visitUtil.MedicalHistoryLines(pid);
            if (lines.Count == 0) { Console.WriteLine("No history."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }
    }
}

