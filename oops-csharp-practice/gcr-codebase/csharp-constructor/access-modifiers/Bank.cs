using System;
public class Bank
    {
        // creating attributes
        public double accountNumber;
        protected string accountHolder;
        private double balance;
        // creating consturctors
        public Bank()
        {
            this.accountNumber=123454321;
            this.accountHolder="Ramesh";
            this.balance=562;
        }
        public Bank(int accountNumber,string accountHolder,double balance)
        {
            this.accountNumber=accountNumber;
            this.accountHolder=accountHolder;
            this.balance=balance;
        }
        // using getter and setter to update balance without giving direct access
        public double GetBalance()
        {
            return balance;
        }
        public void SetBalance(double amount)
        {
            if (amount>=0)
            {
                balance=amount;
            }
            else
            {
                Console.WriteLine("Enter a valid amount");
            }
        }
        public void Display()
        {
            Console.WriteLine($"User {accountHolder} with account number {accountNumber} have {balance}rs in his accounts");
        }
    }
    public class SavingsAccount : Bank
    {
        public SavingsAccount() : base(123454322,"Ojas",7832)
    {
    }
        public void Display()
        {   double bal = GetBalance();
            Console.WriteLine($"{accountHolder} have {bal}rs in his saving accounts with account number {accountNumber}");
        }
    }

