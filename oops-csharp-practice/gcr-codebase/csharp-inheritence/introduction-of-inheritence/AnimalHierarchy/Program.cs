using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Dog("Roger", 3);
            Animal a2 = new Cat("Kitty", 2);
            Animal a3 = new Bird("Bird", 2);

            Console.WriteLine(a1);  // calls Dog.ToString()
            Console.WriteLine(a2);  // calls Cat.ToString()
            Console.WriteLine(a3);
        }
    }
}
