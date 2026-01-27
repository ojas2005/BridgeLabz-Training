using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateHexColor
    {
        static void Main(string[]args)
        {
            string color = Console.ReadLine();
            string pattern = @"^#[0-9A-Fa-f]{6}$";

            Console.WriteLine(Regex.IsMatch(color, pattern) ? "Valid" : "Invalid");
        }
    }
}
