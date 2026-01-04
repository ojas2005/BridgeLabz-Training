using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.RestaurantManagementSystem
{
    internal class Chef : Person, Worker
    {
        string Specialty;

        public Chef(string name, int id, string specialty)
            : base(name, id)
        {
            this.Specialty = specialty;
        }

        public override string ToString()
        {
            return "Chef -> " +
                   base.ToString() +
                   $" , Specialty : {Specialty}";
        }
    }
}
