using System;

namespace RentalApp
{
    internal class Truck : Vehicle
    {
        static double rday=800;

        public Truck(long vid, string vtype) : base(vid, vtype)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("truck info:");
            Console.WriteLine("id: " + vid);
            Console.WriteLine("type: " + vtype);
            Console.WriteLine("rate per day: " + rday);
        }

        public override double CalcRent(Customer cust)
        {
            return cust.dys * rday;
        }
    }
}
