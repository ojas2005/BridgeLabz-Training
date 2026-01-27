using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ExtractDates
    {
        static void Main(string[]args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

            foreach (Match m in Regex.Matches(text, pattern))
                Console.WriteLine(m.Value);
        }
    }
}
