using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateUsername
    {
        static void Main(String[]args)
        {
            string username = Console.ReadLine();
            string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

            Console.WriteLine(Regex.IsMatch(username, pattern) ? "Valid" : "Invalid");
        }
    }
}
