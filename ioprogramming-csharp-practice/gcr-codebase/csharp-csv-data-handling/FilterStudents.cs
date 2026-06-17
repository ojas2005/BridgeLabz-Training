using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class FilterStudents
    {
        static void Main(string[] args)
        {
            const int minimumMarks = 80;

            foreach (var csvLine in File.ReadLines("students.csv"))
            {
                if (csvLine.StartsWith("ID")) 
                    continue;

                var studentFields = csvLine.Split(',');
                int studentMarks = int.Parse(studentFields[3]);

                if (studentMarks > minimumMarks)
                    Console.WriteLine(csvLine);
            }
        }
    }
}
