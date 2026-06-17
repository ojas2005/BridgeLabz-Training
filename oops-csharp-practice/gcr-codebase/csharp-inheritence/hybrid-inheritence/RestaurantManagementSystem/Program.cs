using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.RestaurantManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Chef("Rohit", 789, "Indian Cuisine");
            Person p2 = new Waiter("Amit", 458, 8);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
