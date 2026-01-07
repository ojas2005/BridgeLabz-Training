using System;

namespace FoodApp
{
    internal class VegItem : FoodItem, IDiscountable
    {
        public override double CalcTotal()
        {
            return Fprice * Fqty;
        }

        public double GetDiscount()
        {
            return CalcTotal() * 0.10;
        }

        public string GetDiscInfo()
        {
            return "veg discount 10%";
        }
    }
}
