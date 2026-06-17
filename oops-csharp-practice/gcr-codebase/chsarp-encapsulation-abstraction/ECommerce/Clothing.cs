using System;

namespace StoreApp
{
    internal class Clothing : Product, ITaxable
    {
        public override double GetDiscount()
        {
            return Pprice * 0.20;
        }

        public double GetTax()
        {
            return Pprice * 0.12;
        }

        public string GetTaxInfo()
        {
            return "gst 12%";
        }
    }
}
