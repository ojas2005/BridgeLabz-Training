using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Prescription
    {
        // Prescription identification
        public int PrescriptionId { get; set; }
        public int VisitId { get; set; }
        
        // Medicine details
        public string MedicineName { get; set; } = "";
        public string Dosage { get; set; } = "";
        public int DurationDays { get; set; }
        
        // Additional instructions
        public string? Instructions { get; set; }

        public override string ToString()
        {
            return $"Rx ID: {PrescriptionId} | {MedicineName} | Dosage: {Dosage} | Duration: {DurationDays} days";
        }
    }
}
