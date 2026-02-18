using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Specialty
    {
        // Specialty identification
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = "";
        
        // Status
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{SpecialtyId} | {SpecialtyName} | Active={IsActive}";
        }
    }
}
