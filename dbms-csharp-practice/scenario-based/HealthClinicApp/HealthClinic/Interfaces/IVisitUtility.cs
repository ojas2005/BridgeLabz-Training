using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IVisitUtility
    {
        void RecordVisit(int appointmentId, string diagnosis, string? notes);
        void UpdateVisit(int visitId, string diagnosis, string? notes);
        void DeleteVisit(int visitId);

        List<string> MedicalHistoryLines(int patientId);
    }
}
