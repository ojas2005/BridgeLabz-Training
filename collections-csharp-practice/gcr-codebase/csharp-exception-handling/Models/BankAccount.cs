using System;
using ExceptionHandlingProblems.Exceptions;

namespace ExceptionHandlingProblems.Models
{
    //bank account class with deposit and withdrawal functionality
    public class BankAccount
    {
        //private account balance
        private double balance;

        //account holder name
        public string AccountHolder { get; set; }

        //get account balance
        public double GetBalance()
        {
            return balance;
        }

        //constructor to initialize account with initial balance
        public BankAccount(string accountHolder, double initialBalance)
        {
            AccountHolder = accountHolder;
            balance = initialBalance;
        }

        //deposit money into account
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive");
            }
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");
        }

        //withdraw money from account
        public void Withdraw(double amount)
        {
            //check if amount is negative
            if (amount < 0)
            {
                throw new ArgumentException("Invalid amount! Withdrawal amount cannot be negative");
            }

            //check if balance is sufficient
            if (amount > balance)
            {
                throw new InsufficientFundsException($"Insufficient balance! Available: {balance}, Requested: {amount}");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful, new balance: {balance}");
        }
    }
}
