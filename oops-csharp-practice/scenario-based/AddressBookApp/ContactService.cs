using System;
namespace AddressBookApp
{
public class ContactService
{
    private ContactDirectory[] addressBooks = new ContactDirectory[10];
    private string[] addressBookNames = new string[10];
    private int bookCount = 0;

    public void CreateAddressBook()
    {
        if(bookCount>=addressBooks.Length)
        {
            Console.WriteLine("cannot create more address books, storage full");
            return;
        }
        Console.WriteLine("enter new address book name:");
        string name = Console.ReadLine();
        for(int i=0;i<bookCount;i++)
        {
            if(addressBookNames[i]==name)
            {
                Console.WriteLine("address book with this name already exists");
                return;
            }
        }
        addressBooks[bookCount]=new ContactDirectory();
        addressBookNames[bookCount]=name;
        bookCount++;
        Console.WriteLine("address book created successfully");
    }

    public void SearchPersonByCityOrState()
    {
        Console.WriteLine("enter city or state:");
        string value=Console.ReadLine();
        if(bookCount==0)
        {
            Console.WriteLine("no address books available");
            return;
        }
        for(int i=0;i<bookCount;i++)
        {
            Console.WriteLine($"address book: {addressBookNames[i]}");
            addressBooks[i].SearchByCityOrState(value);
        }
    }


    public void UseAddressBook()
    {
        if(bookCount==0)
        {
            Console.WriteLine("no address books available");
            return;
        }
        Console.WriteLine("enter address book name to open:");
        string name = Console.ReadLine();
        for(int i=0;i<bookCount;i++)
        {
            if(addressBookNames[i]==name)
            {
                ContactDirectory current = addressBooks[i];
                ContactServiceDirectoryMenu(current);
                return;
            }
        }
        Console.WriteLine("address book not found");
    }

    private void ContactServiceDirectoryMenu(ContactDirectory current)
    {
        bool active = true;
        while(active)
        {
            Console.WriteLine("press 1 to add single contact");
            Console.WriteLine("press 2 to add multiple contacts");
            Console.WriteLine("press 3 to edit contact");
            Console.WriteLine("press 4 to delete contact");
            Console.WriteLine("press 5 to display all contacts");
            Console.WriteLine("press 6 to search person by city or state");
            Console.WriteLine("press 7 to to search person by state or city");
            Console.WriteLine("press 8 to search count by city or state");
            Console.WriteLine("press 9 to sort contacts by first name,city,state,zip");
            Console.WriteLine("press 10 to exit");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    AppendContact(current);
                    break;
                case 2:
                    AppendMultipleContacts(current);
                    break;
                case 3:
                    EditContact(current);
                    break;
                case 4:
                    DeleteContact(current);
                    break;
                case 5:
                    current.DisplayAllContacts();
                    break;
                case 6:
                    string placeName = Console.ReadLine();
                    current.SearchByCityOrState(placeName);
                    break;
                case 7:
                    ViewPersonsByCityOrState();
                    break;
                case 8:
                    CountPersonsByCityOrState();
                    break;
                case 9:
                    SortContacts();
                    break;


                case 10:
                    active=false;
                    break;
                default:
                    Console.WriteLine("choose valid option");
                    break;
            }
        }
    }

    public void CountPersonsByCityOrState()
    {
        Console.WriteLine("press 1 to count by city");
        Console.WriteLine("press 2 to count by state");
        int choice=int.Parse(Console.ReadLine());
        if(choice==1)
        {
            Console.WriteLine("enter city:");
            string city=Console.ReadLine();
            int total=0;
            for(int i=0;i<bookCount;i++)
            {
                total+=addressBooks[i].CountByCity(city);
            }
            Console.WriteLine($"total persons in city {city}: {total}");
        }
        else if(choice==2)
        {
            Console.WriteLine("enter state:");
            string state=Console.ReadLine();
            int total=0;
            for(int i=0;i<bookCount;i++)
            {
                total+=addressBooks[i].CountByState(state);
            }
            Console.WriteLine($"total persons in state {state}: {total}");
        }
        else
        {
            Console.WriteLine("invalid choice");
        }
    }
    public void SortContacts()
    {
        Console.WriteLine("press 1 to sort by name");
        Console.WriteLine("press 2 to sort by city");
        Console.WriteLine("press 3 to sort by state");
        Console.WriteLine("press 4 to sort by zip");
        int choice=int.Parse(Console.ReadLine());
        for(int i=0;i<bookCount;i++)
        {
            if(choice==1)
            {
                addressBooks[i].SortByFirstName();
            }
            else if(choice==2)
            {
                addressBooks[i].SortByCity();
            }
            else if(choice==3)
            {
                addressBooks[i].SortByState();
            }
            else if(choice==4)
            {
                addressBooks[i].SortByZip();
            }
        }
        if(count==0)
        {
            Console.WriteLine("no contacts available");
            return;
        }
        for(int i=0;i<count;i++)
        {
            Console.WriteLine("");
            contacts[i].Display();
        }
        Console.WriteLine("contacts sorted successfully");
    }



    private void AppendContact(ContactDirectory dir)
    {
        Console.WriteLine("enter first name:");
        string fn=Console.ReadLine();
        Console.WriteLine("enter last name:");
        string ln=Console.ReadLine();
        Console.WriteLine("enter address:");
        string addr=Console.ReadLine();
        Console.WriteLine("enter city:");
        string city=Console.ReadLine();
        Console.WriteLine("enter state:");
        string state=Console.ReadLine();
        Console.WriteLine("enter zip:");
        string zip=Console.ReadLine();
        Console.WriteLine("enter phone number:");
        string phone=Console.ReadLine();
        Console.WriteLine("enter email:");
        string email=Console.ReadLine();
        ContactPerson contact = new ContactPerson(fn, ln, addr, city, state, zip, phone, email);
        dir.InsertContact(contact);
    }

    private void AppendMultipleContacts(ContactDirectory dir)
    {
        Console.WriteLine("how many contacts do you want to add?");
        int qty=int.Parse(Console.ReadLine());
        for(int i=0;i<qty;i++)
        {
            Console.WriteLine($"entering details for contact {i+1}");
            AppendContact(dir);
        }
    }
    public void ViewPersonsByCityOrState()
    {
        Console.WriteLine("press 1 to view by city");
        Console.WriteLine("press 2 to view by state");
        int choice=int.Parse(Console.ReadLine());
        if(choice==1)
        {
            Console.WriteLine("enter city:");
            string city=Console.ReadLine();
            for(int i=0;i<bookCount;i++)
            {
                Console.WriteLine($"address book: {addressBookNames[i]}");
                addressBooks[i].ViewPersonsByCity(city);
            }
        }
        else if(choice==2)
        {
            Console.WriteLine("enter state:");
            string state=Console.ReadLine();
            for(int i=0;i<bookCount;i++)
            {
                Console.WriteLine($"address book: {addressBookNames[i]}");
                addressBooks[i].ViewPersonsByState(state);
            }
        }
        else
        {
            Console.WriteLine("invalid choice");
        }
    }


    private void EditContact(ContactDirectory dir)
    {
        Console.WriteLine("enter first name to edit:");
        string fn=Console.ReadLine();
        Console.WriteLine("enter last name to edit:");
        string ln=Console.ReadLine();
        dir.EditContact(fn,ln);
    }

    private void DeleteContact(ContactDirectory dir)
    {
        Console.WriteLine("enter first name to delete:");
        string fn=Console.ReadLine();
        Console.WriteLine("enter last name to delete:");
        string ln=Console.ReadLine();
        dir.DeleteContact(fn,ln);
    }

    }
}
