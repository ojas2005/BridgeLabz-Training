using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.VehicleAndTransportManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = new Car(180, "Petrol", 5);
            vehicles[1] = new Truck(120, "Diesel", 10000);
            vehicles[2] = new Motorcycle(160, "Petrol", false);

            // polymorphism using ToString()
            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v);
            }
        }
    }
}
