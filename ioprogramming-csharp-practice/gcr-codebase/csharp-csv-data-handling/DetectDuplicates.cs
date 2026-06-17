using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class DetectDuplicates
    {
        static void Main(string[] args)
        {
            var allRecords = File.ReadLines("data.csv").Skip(1)
                .Select(line => line.Split(','));

            var duplicateItems = allRecords
                .GroupBy(record => record[0])
                .Where(group => group.Count() > 1)
                .SelectMany(group => group);

            foreach (var duplicateRecord in duplicateItems)
                Console.WriteLine(string.Join(",", duplicateRecord));
        }
    }
}
