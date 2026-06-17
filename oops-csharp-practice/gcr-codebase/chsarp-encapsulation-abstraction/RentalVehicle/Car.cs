using System;

namespace RentalApp
{
    internal class Car : Vehicle
    {
        static double rday=500;

        public Car(long vid, string vtype) : base(vid, vtype)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("car info:");
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
