using System;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Handles serialization and deserialization of structured data (student records) using binary format.
    /// Demonstrates reading/writing primitive types with BinaryReader/BinaryWriter.
    /// </summary>
    class BinaryFileDataHandler
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Binary Data File Handler ===\n");

            Console.Write("Enter file path for storage: ");
            string filePath = Console.ReadLine();

            try
            {
                // Collect input data
                StudentRecord studentData = CollectStudentInput();

                // Persist to file
                SaveStudentRecord(filePath, studentData);
                Console.WriteLine("Student record saved successfully.\n");

                // Retrieve from file
                StudentRecord loadedRecord = LoadStudentRecord(filePath);
                DisplayStudentRecord(loadedRecord);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter correct data types.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
        }

        private static StudentRecord CollectStudentInput()
        {
            Console.Write("Enter Roll Number: ");
            int rollNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            return new StudentRecord { RollNumber = rollNumber, Name = name, GPA = gpa };
        }

        private static void SaveStudentRecord(string filePath, StudentRecord record)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(record.RollNumber);
                writer.Write(record.Name);
                writer.Write(record.GPA);
            }
        }

        private static StudentRecord LoadStudentRecord(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                return new StudentRecord
                {
                    RollNumber = reader.ReadInt32(),
                    Name = reader.ReadString(),
                    GPA = reader.ReadDouble()
                };
            }
        }

        private static void DisplayStudentRecord(StudentRecord record)
        {
            Console.WriteLine("Student Record Retrieved:");
            Console.WriteLine($"Roll Number: {record.RollNumber}");
            Console.WriteLine($"Name: {record.Name}");
            Console.WriteLine($"GPA: {record.GPA:F2}");
        }
    }

    /// <summary>
    /// Data model for student records
    /// </summary>
    class StudentRecord
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
    }
}
