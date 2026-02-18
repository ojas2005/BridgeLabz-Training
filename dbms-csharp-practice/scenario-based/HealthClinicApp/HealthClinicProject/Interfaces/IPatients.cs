using HealthClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IPatients
    {
        void AddPatients(Patients patient);
        void UpdatePatients(Patients patient);
        void DeletePatients(int patient_id);
        List<Patients> SearchPatients(string keyword);
        List<String> GetVisitHistory(int patient_id);
    }
}
