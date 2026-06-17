using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.single_inheritence.SmartHomeDevices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device(101, "ON");
            Device thermostat = new Thermostat(102, "ON", 24);

            Console.WriteLine(device);
            Console.WriteLine(thermostat);
        }
    }
}
