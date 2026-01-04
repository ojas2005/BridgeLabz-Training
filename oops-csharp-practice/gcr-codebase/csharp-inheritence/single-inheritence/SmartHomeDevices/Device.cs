using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BridgelabzTraining.inheritence.single_inheritence.SmartHomeDevices
{
    internal class Device
    {
        protected int DeviceId;
        protected string Status;

        // parametrized constructor
        public Device(int deviceId, string status)
        {
            this.DeviceId = deviceId;
            this.Status = status;
        }

        // string override method
        public override string ToString()
        {
            return $"Device ID : {DeviceId} , Status : {Status}";
        }
    }
}
