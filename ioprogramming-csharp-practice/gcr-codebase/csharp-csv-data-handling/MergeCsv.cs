using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class MergeCsv
    {
        static void Main(string[] args)
        {
            var firstDataset = File.ReadLines("students1.csv").Skip(1)
                .Select(line => line.Split(','));

            var secondDataset = File.ReadLines("students2.csv").Skip(1)
                .Select(line => line.Split(','));

            var mergedRecords = from firstRecord in firstDataset
                         join secondRecord in secondDataset on firstRecord[0] equals secondRecord[0]
                         select $"{firstRecord[0]},{firstRecord[1]},{firstRecord[2]},{secondRecord[1]},{secondRecord[2]}";

            var headerWithData = new[] { "ID,Name,Age,Marks,Grade" }.Concat(mergedRecords);
            File.WriteAllLines("merged.csv", headerWithData);
        }
    }
}
