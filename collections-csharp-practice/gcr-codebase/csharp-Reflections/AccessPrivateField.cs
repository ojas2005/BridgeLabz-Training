using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class Person
    {
        private int age = 20;
    }

    class AccessPrivateField
    {
        static void Main()
        {
            Person p = new Person();

            //Fetch Type information of the object (Reflection)
            Type type = p.GetType();

            //Fetch private field "age" using BindingFlags
            FieldInfo field = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

            //Change private field inputValue using Reflection
            field.SetValue(p, 30);

            //Read private field inputValue using Reflection
            Console.WriteLine("Age: " + field.GetValue(p));
        }
    }
}
