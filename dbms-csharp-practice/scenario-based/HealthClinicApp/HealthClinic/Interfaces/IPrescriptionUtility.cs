using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IPrescriptionUtility
    {
        void AddPrescription(int visitId, string medicine, string dosage, int durationDays, string? instructions);
        void UpdatePrescription(int prescriptionId, string medicine, string dosage, int durationDays, string? instructions);
        void DeletePrescription(int prescriptionId);
    }
}
