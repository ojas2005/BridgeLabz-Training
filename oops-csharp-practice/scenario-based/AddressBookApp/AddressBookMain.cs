using System;
namespace AddressBookApp
{
    internal class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");
            ContactDirectory addressBook = new ContactDirectory();
            Console.WriteLine("enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("enter city:");
            string city = Console.ReadLine();
            Console.WriteLine("enter state:");
            string state = Console.ReadLine();
            Console.WriteLine("enter zip:");
            string zip = Console.ReadLine();
            Console.WriteLine("enter phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("enter email:");
            string email = Console.ReadLine();
            ContactPerson person = new ContactPerson(firstName, lastName, address, city, state, zip, phone, email
            );
            addressBook.InsertContact(person);
            Console.WriteLine();
            addressBook.DisplayAllContacts();
            addressBook.EditContact(firstName,lastName);
            addressBook.DisplayAllContacts();
            addressBook.DeleteContact(firstName,lastName);
            addressBook.DisplayAllContacts();
            ContactService svc=new ContactService();
            svc.AppendMultipleContacts();


        }
    }
}