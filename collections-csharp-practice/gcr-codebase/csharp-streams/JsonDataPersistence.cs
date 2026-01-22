using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DataStreamProcessing.DataModel;

namespace DataStreamProcessing
{
    /// <summary>
    /// Handles JSON serialization and deserialization of employee records.
    /// Demonstrates structured data persistence using modern JSON format.
    /// </summary>
    class JsonDataPersistence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== JSON Data Persistence Manager ===\n");

            Console.Write("Enter file path for storage: ");
            string filePath = Console.ReadLine();

            try
            {
                List<Employee> employees = CollectEmployeeData();
                SerializeEmployees(filePath, employees);
                
                Console.WriteLine("Employee records saved successfully.\n");

                List<Employee> retrievedEmployees = DeserializeEmployees(filePath);
                DisplayEmployees(retrievedEmployees);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static List<Employee> CollectEmployeeData()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter number of employees: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Employee {i + 1} ---");

                Console.Write("Employee ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Full Name: ");
                string name = Console.ReadLine();

                Console.Write("Department: ");
                string dept = Console.ReadLine();

                Console.Write("Annual Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmployeeId = id,
                    FullName = name,
                    DepartmentName = dept,
                    AnnualSalary = salary
                });
            }

            return employees;
        }

        private static void SerializeEmployees(string filePath, List<Employee> employees)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(filePath, json);
        }

        private static List<Employee> DeserializeEmployees(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        private static void DisplayEmployees(List<Employee> employees)
        {
            Console.WriteLine("Employee Records Retrieved:");
            Console.WriteLine(new string('-', 70));

            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmployeeId} | Name: {emp.FullName}");
                Console.WriteLine($"  Department: {emp.DepartmentName} | Salary: ${emp.AnnualSalary:F2}");
            }
        }
    }
}
