using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.VehicleAndTransportManagementSystem
{
    public class Motorcycle : Vehicle
    {
        bool HasSidecar;
       public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar)
            : base(maxSpeed, fuelType)
        {
            this.HasSidecar = hasSidecar;
        }
        public override string ToString()
        {
            return "Motor Cycle" +base.ToString()+ $", Has Sidecar : {HasSidecar}";
        }
    }
}
