using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.VehicleAndTransportManagementSystem
{
    public class Truck : Vehicle
    {
        int PayloadCapacity;
        public Truck(int maxSpeed, string fuelType, int payloadCapacity)
            : base(maxSpeed, fuelType)
        {
            this.PayloadCapacity = payloadCapacity;
        }

        public override string ToString()
        {
            return "Truck : " + base.ToString() + $", Payload Capacity : {PayloadCapacity} kg";
        }
    }
}
