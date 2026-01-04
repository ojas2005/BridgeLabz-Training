using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.AnimalHierarchy
{
    public class Bird : Animal
    {
     
            public Bird(string name, int age) : base(name, age)
            {
            }

            public override string ToString()
            {
                return $"Bird Chirps";
            }
        }
    }
