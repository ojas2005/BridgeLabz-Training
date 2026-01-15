using System;
namespace AddressBookApp
{
public class ContactService
{
    private ContactDirectory directory = new ContactDirectory();
    public void AppendContact()
    {
        Console.WriteLine("enter first name:");
        string fn = Console.ReadLine();
        Console.WriteLine("enter last name:");
        string ln = Console.ReadLine();
        Console.WriteLine("enter address:");
        string addr = Console.ReadLine();
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
        ContactPerson contact = new ContactPerson(fn, ln, addr, city, state, zip, phone, email);
        directory.InsertContact(contact);
        Console.WriteLine("contact created successfully");
    }
    public void EditContact()
    {
        Console.WriteLine("enter first name to edit:");
        string fn=Console.ReadLine();
        Console.WriteLine("enter last name to edit:");
        string ln=Console.ReadLine();
        directory.EditContact(fn,ln);
    }

}
}
