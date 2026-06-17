using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class SearchEmployee
    {
        static void Main(string[] args)
        {
            string searchTerm = Console.ReadLine();

            foreach (var csvLine in File.ReadLines("employees.csv"))
            {
                if (csvLine.StartsWith("ID")) 
                    continue;

                var employeeData = csvLine.Split(',');
                if (employeeData[1].Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Department: {employeeData[2]}\nSalary: {employeeData[3]}");
                    return;
                }
            }

            Console.WriteLine("Employee not found");
        }
    }
}
