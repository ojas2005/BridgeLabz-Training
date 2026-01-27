using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }
    class Legacy
    {
        static void Main()
        {
            Animal animal = new Dog();
            animal.MakeSound(); // Output: Dog barks
        }
    }

}
