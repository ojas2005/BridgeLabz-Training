using System;

namespace StoreApp
{
    internal class Electronics : Product, ITaxable
    {
        public override double GetDiscount()
        {
            return Pprice * 0.10;
        }

        public double GetTax()
        {
            return Pprice * 0.18;
        }

        public string GetTaxInfo()
        {
            return "gst 18%";
        }
    }
}
