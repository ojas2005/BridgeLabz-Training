using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ReplaceSpaces
    {
        static void Main(string[]args)
        {
            string text = Console.ReadLine();
            string outcome = Regex.Replace(text, @"\s+", " ");

            Console.WriteLine(outcome);
        }
    }
}
