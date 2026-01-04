using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.VehicleAndTransportManagementSystem
{
    public class Car : Vehicle
    {
        int SeatCapacity;
        public Car(int maxSpeed, string fuelType, int seatCapacity)
            : base(maxSpeed, fuelType)
        {
            this.SeatCapacity = seatCapacity;
        }

        public override string ToString()
        {
            return "Car" + base.ToString() + "Seat Capacity : " + SeatCapacity;
        }
    }
}
