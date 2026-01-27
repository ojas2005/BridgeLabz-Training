using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ExtractEmails
    {
        static void Main(string[]args)
        {
            string email = Console.ReadLine();
            string emailoffice = Console.ReadLine();
            string text = "Contact us at "+email+" and "+emailoffice;
            string pattern = @"\b[\w.%+-]+@[\w.-]+\.[A-Za-z]{2,}\b";

            foreach (Match m in Regex.Matches(text, pattern))
                Console.WriteLine(m.Value);
        }
    }
}
