using System;

namespace BankApp
{
    internal abstract class BankAccount
    {
        private int accNo;
        private string holder;
        private double bal;

        public int AccNo { get { return accNo; } }
        public string Holder { get { return holder; } }
        public double Bal { get { return bal; } }

        public void SetAccNo(int no) { accNo=no; }
        public void SetHolder(string h) { holder=h; }
        public void SetBal(double b) { bal=b; }

        public void Deposit(double amt)
        {
            bal += amt;
        }

        public void Withdraw(double amt)
        {
            if (amt <= bal)
                bal -= amt;
        }

        public abstract double GetInterest();
    }
}
