using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hybrid_inheritence.VehicleManagementSystem
{
    internal class Vehicle
    {
        protected int MaxSpeed;
        protected string Model;

        public Vehicle(int maxSpeed, string model)
        {
            this.MaxSpeed = maxSpeed;
            this.Model = model;
        }

        public override string ToString()
        {
            return $"Model : {Model} , Max Speed : {MaxSpeed}";
        }
    }
}
