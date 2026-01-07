using System;

namespace RentalApp
{
    internal abstract class Vehicle : IRentable
    {
        protected long vid;
        protected string vtype;

        protected Vehicle(long vid, string vtype)
        {
            this.vid=vid;
            this.vtype=vtype;
        }

        public abstract void PrintInfo();
        public abstract double CalcRent(Customer cust);
    }
}
