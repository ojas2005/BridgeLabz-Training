using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.SchoolSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person teacher = new Teacher("Mr. Sharma", 40, "Mathematics");
            Person student = new Student("Aman", 16, "10th Grade");
            Person staff = new Staff("Ramesh", 45, "Office");

            Console.WriteLine(teacher);
            Console.WriteLine(student);
            Console.WriteLine(staff);
        }
    }
}
