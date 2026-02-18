using HealthClinic.Exception;
using HealthClinic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class AuditMenu
    {
        private readonly IAuditUtility _util;
        public AuditMenu(IAuditUtility util) => _util = util;

        public void Start()
        {
            try
            {
                Console.Write("Top N rows (default 50): ");
                var txt = Console.ReadLine();
                int top = string.IsNullOrWhiteSpace(txt) ? 50 : int.Parse(txt);

                var lines = _util.ViewAuditLines(top);
                if (lines.Count == 0) { Console.WriteLine("No audit rows."); return; }
                foreach (var line in lines) Console.WriteLine(line);
            }
            catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }
}
