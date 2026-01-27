using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class StudentInfo
    {
        public int Id;
        public string Name;

        public void Display()
        {
            Console.WriteLine("Hello Student");
        }
    }
    class GetClass
    {
        static void Main(string[] args)
        {
            //Fetch Type info
            Type type = typeof(Student);

            //Create object dynamically
            object obj = Activator.CreateInstance(type);

            //Assign field inputValue
            FieldInfo field = type.GetField("Name");
            field.SetValue(obj, "Rahul");

            //Call method dynamically
            MethodInfo method = type.GetMethod("Display");
            method.Invoke(obj, null);

            //Fetch field inputValue
            Console.WriteLine(field.GetValue(obj));
        }
    }
}