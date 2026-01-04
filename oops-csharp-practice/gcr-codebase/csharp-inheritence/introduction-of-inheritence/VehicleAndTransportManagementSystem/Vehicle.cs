using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.VehicleAndTransportManagementSystem
{
    public class Vehicle
    {
        protected int MaxSpeed;
        protected string FuelType;

        public Vehicle(int maxSpeed, string fuelType)
        {


            this.MaxSpeed = maxSpeed;
            this.FuelType = fuelType;
        }


        // overriding ToString() 
        public override string ToString()
        {
            return $"Max Speed : {MaxSpeed}, Fuel Type : {FuelType}";
        }
    }
}
