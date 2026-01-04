using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.VehicleManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle ev = new ElectricVehicle(160, "Mahindra XEV 9e", 75);
            Vehicle pv = new PetrolVehicle(180, "Honda City", 40);

            Console.WriteLine(ev);
            Console.WriteLine(pv);

            // interface behavior
            Refuelable refuel = new PetrolVehicle(150, "Swift", 37);
            Console.WriteLine(refuel.Refuel());
        }
    }
}
