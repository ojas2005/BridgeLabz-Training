using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ExtractLanguages
    {
        static void Main(string[]args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b(Java|Python|JavaScript|Go)\b";

            foreach (Match m in Regex.Matches(text, pattern))
                Console.WriteLine(m.Value);
        }
    }
}
