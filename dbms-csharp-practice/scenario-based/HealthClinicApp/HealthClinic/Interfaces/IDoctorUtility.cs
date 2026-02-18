using HealthClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IDoctorUtility
    {
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void UpdateDoctorSpecialty(int doctorId, int specialtyId);
        void DeactivateDoctor(int doctorId);

        List<Doctor> GetDoctorsBySpecialty(string specialtyName);
    }
}
