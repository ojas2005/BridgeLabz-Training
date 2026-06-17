using System;

namespace BankApp
{
    internal interface ILoanable
    {
        void ApplyLoan();
        double GetLoanLimit();
    }
}
