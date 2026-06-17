using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Doctor
    {
        // Doctor identification
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = "";
        public int SpecialtyId { get; set; }
        
        // Contact and fee info
        public string? Contact { get; set; }
        public decimal ConsultationFee { get; set; }
        
        // Status flag
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{DoctorId} | {DoctorName} | Fee={ConsultationFee} | SpecId={SpecialtyId} | Active={IsActive}";
        }
    }
}
