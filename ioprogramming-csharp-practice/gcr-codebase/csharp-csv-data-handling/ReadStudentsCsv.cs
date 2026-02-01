using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class ReadStudentsCsv
    {
        static void Main(string[] args)
        {
            using StreamReader csvReader = new StreamReader("students.csv");
            string currentLine;
            bool skipHeaderRow = true;

            while ((currentLine = csvReader.ReadLine()) != null)
            {
                if (skipHeaderRow)
                { 
                    skipHeaderRow = false; 
                    continue; 
                }

                string[] fields = currentLine.Split(',');
                Console.WriteLine($"ID: {fields[0]}, Name: {fields[1]}, Age: {fields[2]}, Marks: {fields[3]}");
            }
        }
    }
}
