using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Thrown when unauthorized access is attempted
    public sealed class UnauthorizedAppException : HealthClinicException
    {
        public UnauthorizedAppException(string message) : base(message) { }
    }
}
