using System;

namespace BridgelabzTraining.class_modeling_and_diagram.csharp_modeling
{
    internal class BankAndAcoountHolders
    {
        static void Main(string[] args)
        {
            Bank b1=new Bank("Punjab National Bank");
            Customer cust1=new Customer("Ojas",7500);
            b1.OpenAccount(cust1);
            cust1.ShowBalance();
        }
    }
    class Bank
    {
        public string bankTitle;
        public Bank(string bankTitle)
        {
            this.bankTitle=bankTitle;
        }
        public void OpenAccount(Customer cust)
        {
            Console.WriteLine($"{cust.customerName} opened account in {bankTitle}");
        }
    }
    class Customer
    {
        public string customerName;
        public double money;
        public Customer(string customerName,double money)
        {
            this.customerName=customerName;
            this.money=money;
        }
        public void ShowBalance()
        {
            Console.WriteLine($"balance is {money}");
        }
    }
}
