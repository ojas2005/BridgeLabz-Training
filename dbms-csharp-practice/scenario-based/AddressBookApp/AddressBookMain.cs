using System;
using AddressBookApp.Services;

namespace AddressBookApp
{
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to AddressBook Program");
                ContactService svc = new ContactService();
                bool running = true;

                while(running)
                {
                    try
                    {
                        Console.WriteLine("press 1 to create new address book");
                        Console.WriteLine("press 2 to open existing address book");
                        Console.WriteLine("press 3 to exit");

                        if(!int.TryParse(Console.ReadLine(), out int choice))
                        {
                            Console.WriteLine("error:- please enter a valid number");
                            continue;
                        }

                        switch(choice)
                        {
                            case 1:
                                svc.CreateAddressBook();
                                break;
                            case 2:
                                svc.UseAddressBook();
                                break;
                            case 3:
                                running = false;
                                break;
                            default:
                                Console.WriteLine("choose valid option");
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"error:-{ex.Message}");
                    }
                }

                Console.WriteLine(" ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:-{ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
