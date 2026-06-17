using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Thrown when record not found
    public sealed class NotFoundException:System.Exception
    {
        public NotFoundException(String message) : base(message) { }
    }
}
