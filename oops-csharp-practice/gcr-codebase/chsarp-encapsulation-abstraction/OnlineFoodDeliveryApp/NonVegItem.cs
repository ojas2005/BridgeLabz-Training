using System;

namespace FoodApp
{
    internal class NonVegItem : FoodItem, IDiscountable
    {
        public override double CalcTotal()
        {
            return (Fprice * Fqty) + 50;
        }

        public double GetDiscount()
        {
            return CalcTotal() * 0.05;
        }

        public string GetDiscInfo()
        {
            return "non-veg discount 5%";
        }
    }
}
