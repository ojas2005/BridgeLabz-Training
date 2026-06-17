using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IAuditUtility
    {
        List<string> ViewAuditLines(int top = 50);
    }
}
