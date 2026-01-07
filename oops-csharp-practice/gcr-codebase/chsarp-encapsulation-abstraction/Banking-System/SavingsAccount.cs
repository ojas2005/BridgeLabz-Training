using System;

namespace BankApp
{
    internal class SavingsAccount : BankAccount, ILoanable
    {
        public override double GetInterest()
        {
            return Bal * 0.04;
        }

        public void ApplyLoan()
        {
            double eligible=GetLoanLimit();

            Console.WriteLine("eligible loan: " + eligible);
            Console.Write("enter loan amount: ");
            double req=double.Parse(Console.ReadLine());

            if (req <= eligible)
            {
                Deposit(req);
                Console.WriteLine("loan approved");
            }
            else
            {
                Console.WriteLine("loan rejected");
            }
        }

        public double GetLoanLimit()
        {
            return Bal * 5;
        }
    }
}
