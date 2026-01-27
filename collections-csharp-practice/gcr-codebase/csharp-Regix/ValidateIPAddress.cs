using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_Regix
{
    internal class ValidateIPAddress
    {
        static void Main(string[]args)
        {
            string ip = Console.ReadLine();
            string pattern =
                @"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.){3}" +
                @"(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$";

            Console.WriteLine(Regex.IsMatch(ip, pattern) ? "Valid" : "Invalid");
        }
    }
}
