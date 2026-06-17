using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.RestaurantManagementSystem
{
    internal class Waiter : Person, Worker
    {
        int TableCount;

        public Waiter(string name, int id, int tableCount)
            : base(name, id)
        {
            this.TableCount = tableCount;
        }

        public override string ToString()
        {
            return "Waiter -> " +
                   base.ToString() +
                   $" , Tables Assigned : {TableCount}";
        }
    }
}
