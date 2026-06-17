using System;

namespace BankApp
{
    internal class CurrentAccount : BankAccount
    {
        public override double GetInterest()
        {
            return Bal * 0.02;
        }
    }
}
