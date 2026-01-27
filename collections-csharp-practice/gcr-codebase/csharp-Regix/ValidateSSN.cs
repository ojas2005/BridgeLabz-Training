using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateSSN
    {
        static void Main(string[]args)
        {
            string ssn = Console.ReadLine();
            string pattern = @"^\d{3}-\d{2}-\d{4}$";

            Console.WriteLine(Regex.IsMatch(ssn, pattern) ? "Valid" : "Invalid");
        }
    }
}
