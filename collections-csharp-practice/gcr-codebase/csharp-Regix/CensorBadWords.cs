using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class CensorBadWords
    {
        static void Main(string[]args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b(damn|stupid)\b";

            string outcome = Regex.Replace(text, pattern, "****", RegexOptions.IgnoreCase);
            Console.WriteLine(outcome);
        }
    }
}
