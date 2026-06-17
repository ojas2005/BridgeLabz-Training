using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Appointment
    {
        // Appointment identification
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        
        // Appointment timing
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        
        // Appointment status
        public string Status { get; set; } = "SCHEDULED";

        public override string ToString()
            => $"{AppointmentId} | P{PatientId} | D{DoctorId} | {AppointmentDate:yyyy-MM-dd} {AppointmentTime:hh\\:mm} | {Status}";
    }
}
