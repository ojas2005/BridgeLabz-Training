using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class UpdateSalaryCsv
    {
        static void Main()
        {
            using var outputWriter = new StreamWriter("updated_employees.csv");
            foreach (var inputLine in File.ReadLines("employees.csv"))
            {
                if (inputLine.StartsWith("ID"))
                {
                    outputWriter.WriteLine(inputLine);
                    continue;
                }

                var employeeFields = inputLine.Split(',');
                if (employeeFields[2] == "IT")
                {
                    double newSalary = double.Parse(employeeFields[3]) * 1.10;
                    employeeFields[3] = newSalary.ToString("F0");
                }
                outputWriter.WriteLine(string.Join(",", employeeFields));
            }
        }
    }
}
