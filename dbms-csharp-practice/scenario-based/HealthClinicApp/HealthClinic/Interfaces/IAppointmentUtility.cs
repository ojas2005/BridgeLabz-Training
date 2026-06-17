using HealthClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IAppointmentUtility
    {
        void Book(Appointment appt);
        void Cancel(int appointmentId, string? reason, string? changedBy);
        void Reschedule(int appointmentId, DateTime newDate, TimeSpan newTime, int? newDoctorId, string? reason, string? changedBy);

        List<string> DailyScheduleLines(DateTime date);
        List<string> DoctorAvailabilityLines(int doctorId, DateTime date);
    }
}
