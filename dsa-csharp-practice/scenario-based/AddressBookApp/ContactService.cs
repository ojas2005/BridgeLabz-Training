using System;

namespace AddressBookApp
{
    public class ContactService
    {
        private HashMap addressBooks = new HashMap(10);
        private int bookCount = 0;

        public void CreateAddressBook()
        {
            Console.WriteLine("enter new address book name:");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("address book with this name already exists");
                return;
            }

            addressBooks.Put(name, new ContactDirectory());
            bookCount++;
            Console.WriteLine("address book created successfully");
        }

        public void SearchPersonByCityOrState()
        {
            Console.WriteLine("enter city or state:");
            string value = Console.ReadLine();

            if (bookCount == 0)
            {
                Console.WriteLine("no address books available");
                return;
            }

            string[] keys = addressBooks.GetAllKeys();
            ContactDirectory[] values = addressBooks.GetAllValues();

            for (int i = 0; i < keys.Length; i++)
            {
                if (values[i] != null)
                {
                    Console.WriteLine($"address book: {keys[i]}");
                    values[i].SearchByCityOrState(value);
                }
            }
        }

        public void UseAddressBook()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("no address books available");
                return;
            }

            Console.WriteLine("enter address book name to open:");
            string name = Console.ReadLine();

            ContactDirectory current = addressBooks.Get(name);

            if (current != null)
                ContactServiceDirectoryMenu(current);
            else
                Console.WriteLine("address book not found");
        }

        private void ContactServiceDirectoryMenu(ContactDirectory current)
        {
            bool active = true;

            while (active)
            {
                Console.WriteLine("press 1 to add single contact");
                Console.WriteLine("press 2 to add multiple contacts");
                Console.WriteLine("press 3 to edit contact");
                Console.WriteLine("press 4 to delete contact");
                Console.WriteLine("press 5 to display all contacts");
                Console.WriteLine("press 6 to search person by city or state");
                Console.WriteLine("press 7 to view persons by city or state");
                Console.WriteLine("press 8 to search count by city or state");
                Console.WriteLine("press 9 to sort contacts");
                Console.WriteLine("press 10 to exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AppendContact(current); break;
                    case 2: AppendMultipleContacts(current); break;
                    case 3: EditContact(current); break;
                    case 4: DeleteContact(current); break;
                    case 5: current.DisplayAllContacts(); break;
                    case 6:
                        Console.WriteLine("enter place:");
                        current.SearchByCityOrState(Console.ReadLine());
                        break;
                    case 7: ViewPersonsByCityOrState(); break;
                    case 8: CountPersonsByCityOrState(); break;
                    case 9: SortContacts(); break;
                    case 10: active = false; break;
                    default: Console.WriteLine("choose valid option"); break;
                }
            }
        }

        public void CountPersonsByCityOrState()
        {
            Console.WriteLine("press 1 to count by city");
            Console.WriteLine("press 2 to count by state");
            int choice = int.Parse(Console.ReadLine());

            int total = 0;
            ContactDirectory[] values = addressBooks.GetAllValues();

            if (choice == 1)
            {
                Console.WriteLine("enter city:");
                string city = Console.ReadLine();

                for (int i = 0; i < values.Length; i++)
                    if (values[i] != null)
                        total += values[i].CountByCity(city);

                Console.WriteLine($"total persons in city {city}: {total}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("enter state:");
                string state = Console.ReadLine();

                for (int i = 0; i < values.Length; i++)
                    if (values[i] != null)
                        total += values[i].CountByState(state);

                Console.WriteLine($"total persons in state {state}: {total}");
            }
        }

        public void SortContacts()
        {
            Console.WriteLine("press 1 to sort by name");
            Console.WriteLine("press 2 to sort by city");
            Console.WriteLine("press 3 to sort by state");
            Console.WriteLine("press 4 to sort by zip");

            int choice = int.Parse(Console.ReadLine());
            ContactDirectory[] values = addressBooks.GetAllValues();

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null) continue;

                if (choice == 1) values[i].SortByFirstName();
                else if (choice == 2) values[i].SortByCity();
                else if (choice == 3) values[i].SortByState();
                else if (choice == 4) values[i].SortByZip();
            }

            Console.WriteLine("contacts sorted successfully");
        }

        public void ViewPersonsByCityOrState()
        {
            Console.WriteLine("press 1 to view by city");
            Console.WriteLine("press 2 to view by state");
            int choice = int.Parse(Console.ReadLine());

            string[] keys = addressBooks.GetAllKeys();
            ContactDirectory[] values = addressBooks.GetAllValues();

            if (choice == 1)
            {
                Console.WriteLine("enter city:");
                string city = Console.ReadLine();

                for (int i = 0; i < keys.Length; i++)
                    if (values[i] != null)
                    {
                        Console.WriteLine($"address book: {keys[i]}");
                        values[i].ViewPersonsByCity(city);
                    }
            }
            else if (choice == 2)
            {
                Console.WriteLine("enter state:");
                string state = Console.ReadLine();

                for (int i = 0; i < keys.Length; i++)
                    if (values[i] != null)
                    {
                        Console.WriteLine($"address book: {keys[i]}");
                        values[i].ViewPersonsByState(state);
                    }
            }
        }

        private void AppendContact(ContactDirectory dir)
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
            dir.InsertContact(contact);
        }

        private void AppendMultipleContacts(ContactDirectory dir)
        {
            Console.WriteLine("how many contacts do you want to add?");
            int qty = int.Parse(Console.ReadLine());

            for (int i = 0; i < qty; i++)
            {
                Console.WriteLine($"entering details for contact {i + 1}");
                AppendContact(dir);
            }
        }

        private void EditContact(ContactDirectory dir)
        {
            Console.WriteLine("enter first name to edit:");
            string fn = Console.ReadLine();
            Console.WriteLine("enter last name to edit:");
            string ln = Console.ReadLine();
            dir.EditContact(fn, ln);
        }

        private void DeleteContact(ContactDirectory dir)
        {
            Console.WriteLine("enter first name to delete:");
            string fn = Console.ReadLine();
            Console.WriteLine("enter last name to delete:");
            string ln = Console.ReadLine();
            dir.DeleteContact(fn, ln);
        }
    }
}
