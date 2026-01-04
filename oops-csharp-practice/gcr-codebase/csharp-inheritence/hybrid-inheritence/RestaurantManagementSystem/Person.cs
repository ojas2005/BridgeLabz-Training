using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.RestaurantManagementSystem
{

    internal class Person
    {
        protected string Name;
        protected int Id;

        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Name : {Name} , ID : {Id}";
        }
    }
}
