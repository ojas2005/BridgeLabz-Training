using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.single_inheritence.SmartHomeDevices
{
    internal class Thermostat : Device
    {
        int TemperatureSetting;

        // constructor 
        public Thermostat(int deviceId, string status, int temperature)
            : base(deviceId, status)
        {
            this.TemperatureSetting = temperature; // givng refernce to object
        }

        // string override
        public override string ToString()
        {
            return base.ToString() + $" , Temperature : {TemperatureSetting}";
        }
    }
}
