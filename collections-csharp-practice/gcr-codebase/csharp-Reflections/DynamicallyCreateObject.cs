using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class Student
    {
        public string Name;

        public Student(string name)
        {
            Name = name;
        }
    }

    class DynamicallyCreateObject
    {
        static void Main()
        {
            Type type = typeof(Student);
            object obj = Activator.CreateInstance(type, "Emma");
            Student s = (Student)obj;

            Console.WriteLine("Student Name: " + s.Name);
        }
    }
}
