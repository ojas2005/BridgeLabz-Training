using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.SchoolSystem
{
    internal class Person
    {
        protected string Name;
        protected int Age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name : {Name} , Age : {Age}";
        }
    }
}
