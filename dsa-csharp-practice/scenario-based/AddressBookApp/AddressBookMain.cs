using System;
namespace AddressBookApp
{
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");
            ContactService svc=new ContactService();
            bool running=true;
            while(running)
            {
                Console.WriteLine("press 1 to create new address book");
                Console.WriteLine("press 2 to open existing address book");
                Console.WriteLine("press 3 to exit");
                int choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        svc.CreateAddressBook();
                        break;
                    case 2:
                        svc.UseAddressBook();
                        break;
                    case 3:
                        running=false;
                        break;
                    default:
                        Console.WriteLine("choose valid option");
                        break;
                }
            }
        }
    }
}
