using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Thrown when business logic rules are violated
    public sealed class BusinessRuleException : HealthClinicException
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
