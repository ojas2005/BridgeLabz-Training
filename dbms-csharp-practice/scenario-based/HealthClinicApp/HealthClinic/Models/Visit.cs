using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Visit
    {
        // Visit identification
        public int VisitId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime VisitDate { get; set; }
        
        // Medical information
        public string Diagnosis { get; set; } = "";
        public string? Notes { get; set; }

        public override string ToString()
        {
            return $"Visit ID: {VisitId} | Appointment: {AppointmentId} | Date: {VisitDate:yyyy-MM-dd} | Diagnosis: {Diagnosis}";
        }
    }
}
