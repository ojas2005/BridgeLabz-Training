using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Sumit", 785, 5000000);
            Employee manager = new Manager("Sahil", 4564, 500000, 5);
            Employee developer = new Developer("Abhay", 759, 500000, "C#");
            Employee intern = new Intern("Pushpak", 987, 155656, "6 months");

            Console.WriteLine(employee);
            Console.WriteLine(manager);
            Console.WriteLine(developer);
            Console.WriteLine(intern);

        }
        
    }
}
