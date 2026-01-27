using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateLicensePlate
    {
        static void Main(string[]args)
        {
            string plate = Console.ReadLine();
            string pattern = @"^[A-Z]{2}\d{4}$";

            Console.WriteLine(Regex.IsMatch(plate, pattern) ? "Valid" : "Invalid");
        }
    }
}
