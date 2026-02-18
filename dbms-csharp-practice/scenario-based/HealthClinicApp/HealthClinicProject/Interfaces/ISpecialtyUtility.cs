using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface ISpecialtyUtility
    {
        void AddSpecialty(string name);
        void UpdateSpecialty(int id, string name, bool isActive);
        void DeleteSpecialty(int id); // soft delete (is_active=0)
    }
}
