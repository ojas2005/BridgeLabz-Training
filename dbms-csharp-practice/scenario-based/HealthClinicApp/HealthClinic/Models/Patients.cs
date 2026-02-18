using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Patients
    {
        // Patient core properties
        public int patient_id { get; set; }
        public string full_name { get; set; } = "";
        public DateTime dob { get; set; }
        public string phone { get; set; }
        
        // Optional patient info
        public string? email { get; set; }
        public string? address { get; set; }
        public string? blood_group { get; set; }

        public override string ToString()
        {
            return "Patient ID: " + patient_id + "\nFull Name: " + full_name + "\nDate Of Birth" + dob + "\nPhone Number: " + phone + "\nEmail: " + email + "\nAddress: " + address + "\nBlood Group: " + blood_group;
        }
    }
}
