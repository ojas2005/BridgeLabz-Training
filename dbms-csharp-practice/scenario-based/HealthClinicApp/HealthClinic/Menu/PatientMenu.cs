using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using HealthClinic.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class PatientMenu
    {
        private readonly IPatients _util;

        public PatientMenu(IPatients util) => _util = util;

        // HELPER INPUT
        private static Patients Read(bool requireId)
        {
            var p = new Patients();

            if (requireId)
            {
                Console.Write("Patient ID: ");
                p.patient_id = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.Write("Full name: ");
            p.full_name = Console.ReadLine() ?? "";

            Console.Write("DOB (yyyy-mm-dd): ");
            p.dob = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Phone: ");
            p.phone = Console.ReadLine() ?? "";

            Console.Write("Email (optional): ");
            var e = Console.ReadLine();
            p.email = string.IsNullOrWhiteSpace(e) ? null : e.Trim();

            Console.Write("Address (optional): ");
            var a = Console.ReadLine();
            p.address = string.IsNullOrWhiteSpace(a) ? null : a.Trim();

            Console.Write("Blood group (optional): ");
            var bg = Console.ReadLine();
            p.blood_group = string.IsNullOrWhiteSpace(bg) ? null : bg.Trim();

            return p;
        }

        // ACTION ADD
        private void Add()
        {
            var p = Read(requireId: false);
            _util.AddPatients(p);
            Console.WriteLine("Patient added.");
        }

        // ACTION UPDATE
        private void Update()
        {
            var p = Read(requireId: true);
            _util.UpdatePatients(p);
            Console.WriteLine("Patient updated.");
        }

        // ACTION DELETE
        private void Delete()
        {
            Console.Write("Patient ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            _util.DeletePatients(id);
            Console.WriteLine("Patient deleted.");
        }

        // ACTION SEARCH
        private void Search()
        {
            Console.Write("Keyword (name/phone/email): ");
            var k = Console.ReadLine() ?? "";
            var list = _util.SearchPatients(k);
            if (list.Count == 0) { Console.WriteLine("No records."); return; }
            foreach (var p in list) Console.WriteLine(p);
        }

        // ACTION HISTORY
        private void History()
        {
            Console.Write("Patient ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            var lines = _util.GetVisitHistory(id);
            if (lines.Count == 0) { Console.WriteLine("No history."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }

        // MAIN MENU LOOP
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n--- Patient Menu ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. Search Patients");
                Console.WriteLine("5. Visit History");
                Console.WriteLine("0. Back");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": Add(); break;
                        case "2": Update(); break;
                        case "3": Delete(); break;
                        case "4": Search(); break;
                        case "5": History(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
