using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class CountCsvRows
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("students.csv");
            int recordCount = allLines.Length - 1;
            Console.WriteLine($"Total Records: {recordCount}");
        }
    }
}
