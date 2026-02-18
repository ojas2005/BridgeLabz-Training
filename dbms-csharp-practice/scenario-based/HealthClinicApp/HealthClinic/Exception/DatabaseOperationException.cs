using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Exception
{
    //Thrown when database operations fail
    public sealed class DatabaseOperationException:System.Exception
    {
        public DatabaseOperationException(string message, System.Exception inner) : base(message, inner) { }
    }
}
