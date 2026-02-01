using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public int Marks;

        public override string ToString() =>
            $"{Id} {Name} {Age} {Marks}";
    }

    internal class CsvToObjects
    {
        static void Main(string[] args)
        {
            List<Student> studentCollection = new();

            foreach (var csvLine in File.ReadLines("students.csv").Skip(1))
            {
                var lineFields = csvLine.Split(',');
                var newStudent = new Student
                {
                    Id = int.Parse(lineFields[0]),
                    Name = lineFields[1],
                    Age = int.Parse(lineFields[2]),
                    Marks = int.Parse(lineFields[3])
                };
                studentCollection.Add(newStudent);
            }

            studentCollection.ForEach(Console.WriteLine);
        }
    }
}
