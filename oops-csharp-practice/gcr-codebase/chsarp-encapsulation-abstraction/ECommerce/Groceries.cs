using System;

namespace StoreApp
{
    internal class Groceries : Product
    {
        public override double GetDiscount()
        {
            return Pprice * 0.05;
        }
    }
}
