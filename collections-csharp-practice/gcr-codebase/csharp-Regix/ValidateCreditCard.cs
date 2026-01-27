using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateCreditCard
    {
        static void Main(string[]args)
        {
            string card = Console.ReadLine();
            string pattern = @"^(4\d{15}|5\d{15})$";

            Console.WriteLine(Regex.IsMatch(card, pattern) ? "Valid" : "Invalid");
        }
    }
}
