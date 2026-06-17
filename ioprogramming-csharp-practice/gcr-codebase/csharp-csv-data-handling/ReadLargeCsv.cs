using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class ReadLargeCsv
    {
        static void Main(string[] args)
        {
            using StreamReader fileReader = new StreamReader("large.csv");
            int processedCount = 0;
            string currentRecord;
            const int batchSize = 100;

            while (!fileReader.EndOfStream)
            {
                for (int batchIndex = 0; batchIndex < batchSize && (currentRecord = fileReader.ReadLine()) != null; batchIndex++)
                    processedCount++;

                Console.WriteLine($"Processed: {processedCount}");
            }
        }
    }
}
