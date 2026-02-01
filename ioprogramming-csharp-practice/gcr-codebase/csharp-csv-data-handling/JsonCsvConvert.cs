using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class JsonCsvConvert
    {
        static void Main(string[] args)
        {
            string jsonContent = File.ReadAllText("students.json");
            var studentList = JsonSerializer.Deserialize<List<Student>>(jsonContent);

            using StreamWriter csvWriter = new StreamWriter("students.csv");
            csvWriter.WriteLine("Id,Name,Age,Marks");

            foreach (var student in studentList)
                csvWriter.WriteLine($"{student.Id},{student.Name},{student.Age},{student.Marks}");
        }
    }
}
