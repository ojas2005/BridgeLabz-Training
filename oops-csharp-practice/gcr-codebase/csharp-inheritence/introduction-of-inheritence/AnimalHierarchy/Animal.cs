using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.AnimalHierarchy
{
    public class Animal
    {
        protected string Name;
        protected int Age;

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Animal makes Sound";
        }
    }
}
