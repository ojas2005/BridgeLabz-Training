using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.Multilevel_Inheritance.OnlineRetailOrderManagement
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // creating object 
            Order order = new Order(101, "01-09-2024");
            Order shippedOrder = new ShippedOrder(102, "02-09-2024", "TRK12345");
            Order deliveredOrder = new DeliveredOrder(103, "03-09-2024", "TRK67890", "05-09-2024");

            Console.WriteLine(order);
            Console.WriteLine(shippedOrder);
            Console.WriteLine(deliveredOrder);
        }
    }
}
