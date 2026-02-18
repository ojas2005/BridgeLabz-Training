using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class DoctorManagementMenu
    {
        private readonly IDoctorUtility _util;
        public DoctorManagementMenu(IDoctorUtility util) => _util = util;

        // HELPER INPUT
        private static Doctor Read(bool requireId)
        {
            var d = new Doctor();

            if (requireId)
            {
                Console.Write("Doctor ID: ");
                d.DoctorId = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.Write("Doctor name: ");
            d.DoctorName = Console.ReadLine() ?? "";

            Console.Write("Contact (optional): ");
            var c = Console.ReadLine();
            d.Contact = string.IsNullOrWhiteSpace(c) ? null : c.Trim();

            Console.Write("Consultation fee: ");
            d.ConsultationFee = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Specialty ID: ");
            d.SpecialtyId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Is Active (true/false): ");
            d.IsActive = bool.Parse(Console.ReadLine() ?? "true");

            return d;
        }

        // ACTION ADD
        private void Add()
        {
            var d = Read(requireId: false);
            _util.AddDoctor(d);
            Console.WriteLine("Doctor added.");
        }

        // ACTION UPDATE
        private void Update()
        {
            var d = Read(requireId: true);
            _util.UpdateDoctor(d);
            Console.WriteLine("Doctor updated.");
        }

        // ACTION SPECIALTY
        private void UpdateSpec()
        {
            Console.Write("Doctor ID: ");
            var docId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Specialty ID: ");
            var spId = int.Parse(Console.ReadLine() ?? "0");
            _util.UpdateDoctorSpecialty(docId, spId);
            Console.WriteLine("Doctor specialty updated.");
        }

        // ACTION DEACTIVATE
        private void Deactivate()
        {
            Console.Write("Doctor ID: ");
            var docId = int.Parse(Console.ReadLine() ?? "0");
            _util.DeactivateDoctor(docId);
            Console.WriteLine("Doctor deactivated.");
        }

        // ACTION SEARCH SPECIALTY
        private void BySpec()
        {
            Console.Write("Specialty name: ");
            var name = Console.ReadLine() ?? "";
            var docs = _util.GetDoctorsBySpecialty(name);
            if (docs.Count == 0) { Console.WriteLine("No doctors."); return; }
            foreach (var d in docs) Console.WriteLine(d);
        }

        // MAIN MENU LOOP
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n--- Doctor Management Menu ---");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Update Doctor Specialty");
                Console.WriteLine("4. Deactivate Doctor");
                Console.WriteLine("5. View Doctors by Specialty Name");
                Console.WriteLine("0. Back");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": Add(); break;
                        case "2": Update(); break;
                        case "3": UpdateSpec(); break;
                        case "4": Deactivate(); break;
                        case "5": BySpec(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
