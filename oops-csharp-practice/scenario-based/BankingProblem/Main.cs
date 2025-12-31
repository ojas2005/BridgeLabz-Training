using System;

class MainApp
{
    static void Main()
    {
        Manager manager = new Manager();
        BankAccount bankAccount = null;
        while (true)
        {
            Console.WriteLine("-----------------BANK SYSTEM MENU--------------------");
            Console.WriteLine("Press 1 for Manager Login");
            Console.WriteLine("Press 2 for User Login");
            Console.WriteLine("Press 3 to Exit");
            int choice=int.Parse(Console.ReadLine());
            if (choice==1)
            {
                Console.Write("username: ");
                string id = Console.ReadLine();
                Console.Write("password: ");
                string pass = Console.ReadLine();
                if (manager.ManagerAuthentication(id,pass)==false)
                {
                    break;
                }
                while (true)
                {
                    Console.WriteLine("What Services do you want to use?");
                    Console.WriteLine("Press 1 to Add a New User");
                    Console.WriteLine("Press 2 to Update User Balance");
                    Console.WriteLine("Press 3 to Delete a User");
                    Console.WriteLine("Press 4 to List all Users");
                    Console.WriteLine("Press 5 to return to the main menu");
                    int managerChoice=int.Parse(Console.ReadLine());
                    if (managerChoice==1)
                    {
                        Console.WriteLine("enter account number");
                        int accountNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("pin");
                        int pin = int.Parse(Console.ReadLine());
                        double balance = 0;
                        manager.AddNewUser(accountNumber,pin,balance);
                    }
                    else if (managerChoice==2)
                    {
                        Console.Write("account number");
                        int accountNumber = int.Parse(Console.ReadLine());
                        Console.Write("new balance");
                        double balance = double.Parse(Console.ReadLine());
                        manager.UpdateBalance(accountNumber,balance);
                    }
                    else if (managerChoice==3)
                    {
                        Console.Write("account number");
                        int accountNumber = int.Parse(Console.ReadLine());
                        manager.DeleteUser(accountNumber);
                    }
                    else if (managerChoice==4)
                    {
                        manager.ListUsers();
                    }
                    else if (managerChoice==5)
                    {
                        break;
                    }
                }
            }
            else if(choice==2)
            {
                Console.Write("account number");
                string accountNumber = Console.ReadLine();
                Console.Write("username");
                string username = Console.ReadLine();
                Console.Write("enter ifsc code");
                string ifsc = Console.ReadLine();
                double balance = 0;
                bankAccount = new BankAccount(accountNumber,balance,username,ifsc);
                while (true)
                {
                    Console.WriteLine("What Services do you want to use?");
                    Console.WriteLine("Press 1 to Deposit an amount");
                    Console.WriteLine("Press 2 to Withdraw");
                    Console.WriteLine("Press 3 to Check Balance");
                    Console.WriteLine("Press 4 to Back");
                    int userChoice=int.Parse(Console.ReadLine());
                    if (userChoice==1)
                    {
                        Console.WriteLine("enter the amount you want to deposit");
                        double amount = double.Parse(Console.ReadLine());
                        bankAccount.Deposit(amount);
                    }
                    else if (userChoice==2)
                    {
                        Console.Write("enter amount");
                        double amount = double.Parse(Console.ReadLine());
                        bankAccount.Withdraw(amount);
                    }
                    else if (userChoice==3)
                    {
                        bankAccount.BalanceCheck();
                    }
                    else if (userChoice==4)
                    {
                        break;
                    }
                }
            }
            else if(choice==3)
            {
                Console.WriteLine("exiting the application.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }
    }
}
