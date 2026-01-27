using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ExtractCapitalizedWords
    {
        static void Main(string[]args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]*\b";

            foreach (Match m in Regex.Matches(text, pattern))
                Console.WriteLine(m.Value);
        }
    }
}
