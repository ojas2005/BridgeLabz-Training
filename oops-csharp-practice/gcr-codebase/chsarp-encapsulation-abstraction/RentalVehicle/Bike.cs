using System;

namespace RentalApp
{
    internal class Bike : Vehicle
    {
        static double rday=150;

        public Bike(long vid, string vtype) : base(vid, vtype)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("bike info:");
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
