using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class ValidateCsv
    {
        static void Main(string[] args)
        {
            var emailValidator = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            var phoneValidator = new Regex(@"^\d{10}$");
            const int emailFieldIndex = 2;
            const int phoneFieldIndex = 3;

            foreach (var dataLine in File.ReadLines("data.csv").Skip(1))
            {
                var recordFields = dataLine.Split(',');
                bool isEmailValid = emailValidator.IsMatch(recordFields[emailFieldIndex]);
                bool isPhoneValid = phoneValidator.IsMatch(recordFields[phoneFieldIndex]);

                if (!isEmailValid || !isPhoneValid)
                    Console.WriteLine($"Invalid Row: {dataLine}");
            }
        }
    }
}
