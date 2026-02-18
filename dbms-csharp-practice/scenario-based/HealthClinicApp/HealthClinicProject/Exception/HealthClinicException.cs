using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Base exception for all clinic operations
    public class HealthClinicException:System.Exception
    {
        public HealthClinicException(string message) : base(message) { }
        public HealthClinicException(string message, System.Exception inner):base(message, inner) { }
    }
}
