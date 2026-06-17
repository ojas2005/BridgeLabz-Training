using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Thrown when input validation fails
    public sealed class ValidationException:System.Exception
    {
        public ValidationException(String message) : base(message) { }
    }
}
