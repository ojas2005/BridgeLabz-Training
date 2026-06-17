using System;

class BankAccount
{
    private string accountNumber;
    private double balance;
    public string username;
    public string ifscCode;
    public BankAccount(string accountNumber, double balance, string username, string ifscCode)
    {
        this.accountNumber = accountNumber;
        this.balance = balance;
        this.username = username;
        this.ifscCode = ifscCode;
    }
    public void BalanceCheck()
    {
        Console.WriteLine($"Your current account balance is: {balance}");
    }
    public void Withdraw(double amount)
    {
        if (amount<=balance)
        {
            balance=balance-amount;
            Console.WriteLine($"You have withdrawn {amount}rs from your account");
        }
        else
        {
            Console.WriteLine($"Can't withdraw {amount}rs from your account as your balance is low,Current balance: {balance}");
        }
    }
    public void Deposit(double amount)
    {
        balance=balance+amount;
        Console.WriteLine($"You have deposited {amount}rs to your account.Now your account balance has been updated,Current balance: {balance}");
    }
    
}

