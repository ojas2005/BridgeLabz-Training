using System;

class User
{
    public int accountNumber;
    public int pin;
    public double balance;
    public string lastTransaction;
    public User(int accountNumber, int pin, double balance)
    {
        this.accountNumber=accountNumber;
        this.pin=pin;
        this.balance=balance;
        this.lastTransaction=lastTransaction;
    }
    public void Deposit(double amount)
    {
        balance=balance+amount;
        lastTransaction = "Deposited " + amount;
    }
    public void Credit(double amount)
    {
        if (amount<=balance)
        {
            balance=balance-amount;
            lastTransaction = "Credited " + amount ;
            Console.WriteLine($"You have credited  {amount}rs from your account");
        }
        else
        {
            lastTransaction= "Transaction failed";
            Console.WriteLine($"You can't credited  {amount}rs from your account as your account balance is low");
        }
    }
    public void CheckBalance()
    {
        Console.WriteLine($"Your current balance is {balance}");
    }
    public void ShowTransaction()
    {
        Console.WriteLine($"The last Transaction you have made is {lastTransaction}");
    }
}
