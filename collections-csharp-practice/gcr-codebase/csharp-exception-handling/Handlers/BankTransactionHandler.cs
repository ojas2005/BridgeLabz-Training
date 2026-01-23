using System;
using ExceptionHandlingProblems.Models;
using ExceptionHandlingProblems.Exceptions;

namespace ExceptionHandlingProblems.Handlers
{
    //handles bank account transactions with custom exception handling
    public class BankTransactionHandler
    {
        //run bank transaction demo
        public static void Run()
        {
            Console.WriteLine("\n===== Bank Transaction System =====");

            //create bank account with initial balance
            BankAccount account = new BankAccount("John Doe", 1000);
            Console.WriteLine($"Account holder: {account.AccountHolder}");
            Console.WriteLine($"Initial balance: {account.GetBalance()}\n");

            bool transacting = true;

            while (transacting)
            {
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Select operation: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //withdrawal operation
                        Console.Write("Enter withdrawal amount: ");
                        string withdrawInput = Console.ReadLine();

                        try
                        {
                            double withdrawAmount = double.Parse(withdrawInput);
                            account.Withdraw(withdrawAmount);
                        }
                        catch (ArgumentException ex)
                        {
                            //handle invalid amount argument
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (InsufficientFundsException ex)
                        {
                            //handle insufficient balance
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (FormatException)
                        {
                            //handle invalid input format
                            Console.WriteLine("Error: Please enter a valid number");
                        }
                        break;

                    case "2":
                        //deposit operation
                        Console.Write("Enter deposit amount: ");
                        string depositInput = Console.ReadLine();

                        try
                        {
                            double depositAmount = double.Parse(depositInput);
                            account.Deposit(depositAmount);
                        }
                        catch (ArgumentException ex)
                        {
                            //handle invalid amount argument
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (FormatException)
                        {
                            //handle invalid input format
                            Console.WriteLine("Error: Please enter a valid number");
                        }
                        break;

                    case "3":
                        //check balance
                        Console.WriteLine($"Current balance: {account.GetBalance()}");
                        break;

                    case "4":
                        //exit operation
                        transacting = false;
                        Console.WriteLine("Thank you for banking with us!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (transacting)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
