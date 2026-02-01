using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class SortBySalary
    {
        static void Main(string[] args)
        {
            const int topCount = 5;
            const int salaryIndex = 3;
            const int nameIndex = 1;

            var topEarners = File.ReadLines("employees.csv")
                .Skip(1)
                .Select(line => line.Split(','))
                .OrderByDescending(fields => int.Parse(fields[salaryIndex]))
                .Take(topCount);

            foreach (var employeeRecord in topEarners)
                Console.WriteLine($"{employeeRecord[nameIndex]} - {employeeRecord[salaryIndex]}");
        }
    }
}
