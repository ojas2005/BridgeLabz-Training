using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AddressBookApp
{
    public class ContactService : IAddressBookService
    {
        private readonly HashMap addressBooks = new HashMap();
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;
        private readonly object _lock = new object();

        public void CreateAddressBook()
        {
            lock (_lock)
            {
                try
                {
                    Console.WriteLine("enter new address book name:");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                        throw new ArgumentException("Address book name cannot be empty", nameof(name));

                    if (addressBooks.ContainsKey(name))
                    {
                        _logger.Log($"Address book with name '{name}' already exists");
                        return;
                    }

                    addressBooks.Put(name, new ContactDirectory());
                    _logger.Log($"Address book created successfully: {name}");
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError("Failed to create address book", ex);
                    throw new AddressBookException("Failed to create address book", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error creating address book", ex);
                    throw new AddressBookException("Unexpected error creating address book", ex);
                }
            }
        }

        public void SearchPersonByCityOrState()
        {
            lock (_lock)
            {
                try
                {
                    if (addressBooks.Size == 0)
                    {
                        _logger.Log("No address books available for search");
                        return;
                    }

                    Console.WriteLine("enter city or state:");
                    string value = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Search value cannot be empty", nameof(value));

                    string[] keys = addressBooks.GetAllKeys();
                    ContactDirectory[] values = addressBooks.GetAllValues();

                    foreach (var x in keys.AsEnumerable()
                        .Zip(values.AsEnumerable(), (k, v) => new { Key = k, Value = v })
                        .Where(x => x.Value != null))
                    {
                        Console.WriteLine($"address book: {x.Key}");
                        x.Value.SearchByCityOrState(value);
                    }

                    _logger.Log($"Search completed for: {value}");
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError("Search validation failed", ex);
                    throw new ContactException("Search operation failed", ex);
                }
                catch (ContactException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error during search", ex);
                    throw new ContactException("Unexpected error during search", ex);
                }
            }
        }

        public void UseAddressBook()
        {
            lock (_lock)
            {
                try
                {
                    if (addressBooks.Size == 0)
                    {
                        _logger.Log("No address books available");
                        return;
                    }

                    Console.WriteLine("enter address book name to open:");
                    string name = Console.ReadLine();

                    ContactDirectory current = addressBooks.Get(name);

                    if (current != null)
                    {
                        _logger.Log($"Opening address book: {name}");
                        ContactServiceDirectoryMenu(current);
                    }
                    else
                    {
                        _logger.Log($"Address book not found: {name}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error opening address book", ex);
                    throw new AddressBookException("Failed to open address book", ex);
                }
            }
        }

        private void ContactServiceDirectoryMenu(ContactDirectory current)
        {

            while (true)
            {
                try
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
                            Console.WriteLine("enter place:");
                            current.SearchByCityOrState(Console.ReadLine());
                            break;
                        case 7: 
                            ViewPersonsByCityOrState(current); 
                            break;
                        case 8: 
                            CountPersonsByCityOrState(current); 
                            break;
                        case 9: 
                            SortContacts(current); 
                            break;
                        case 10: 
                            return;
                        default: 
                            Console.WriteLine("choose valid option"); 
                            break;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("error: please enter a valid number");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"error: {ex.Message}");
                }
            }
        }

        public void CountPersonsByCityOrState(ContactDirectory current)
        {
            try
            {
                Console.WriteLine("press 1 to count by city");
                Console.WriteLine("press 2 to count by state");
                int choice = int.Parse(Console.ReadLine());

                if(choice == 1)
                {
                    Console.WriteLine("enter city:");
                    string city = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(city))
                        throw new ArgumentException("city cannot be empty");

                    int total = current.CountByCity(city);
                    Console.WriteLine($"total persons in city {city}: {total}");
                }
                else if(choice == 2)
                {
                    Console.WriteLine("enter state:");
                    string state = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(state))
                        throw new ArgumentException("state cannot be empty");

                    int total = current.CountByState(state);
                    Console.WriteLine($"total persons in state {state}: {total}");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("error: please enter a valid number");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public void SortContacts(ContactDirectory current)
        {
            try
            {
                Console.WriteLine("press 1 to sort by name");
                Console.WriteLine("press 2 to sort by city");
                Console.WriteLine("press 3 to sort by state");
                Console.WriteLine("press 4 to sort by zip");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: current.SortByFirstName(); break;
                    case 2: current.SortByCity(); break;
                    case 3: current.SortByState(); break;
                    case 4: current.SortByZip(); break;
                    default: Console.WriteLine("choose valid option"); return;
                }

                Console.WriteLine("contacts sorted successfully");
            }
            catch(FormatException)
            {
                Console.WriteLine("error: please enter a valid number");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error sorting: {ex.Message}");
            }
        }

        public void ViewPersonsByCityOrState(ContactDirectory current)
        {
            try
            {
                Console.WriteLine("press 1 to view by city");
                Console.WriteLine("press 2 to view by state");
                int choice = int.Parse(Console.ReadLine());

                if(choice == 1)
                {
                    Console.WriteLine("enter city:");
                    string city = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(city))
                        throw new ArgumentException("city cannot be empty");

                    current.ViewPersonsByCity(city);
                }
                else if(choice == 2)
                {
                    Console.WriteLine("enter state:");
                    string state = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(state))
                        throw new ArgumentException("state cannot be empty");

                    current.ViewPersonsByState(state);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("error: please enter a valid number");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        private void AppendContact(ContactDirectory dir)
        {
            try
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
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error adding contact: {ex.Message}");
            }
        }

        private void AppendMultipleContacts(ContactDirectory dir)
        {
            try
            {
                Console.WriteLine("how many contacts do you want to add?");
                int qty = int.Parse(Console.ReadLine());

                if(qty <= 0)
                    throw new ArgumentException("quantity must be greater than zero");

                for (int i = 0; i < qty; i++)
                {
                    Console.WriteLine($"entering details for contact {i + 1}");
                    AppendContact(dir);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("error: please enter a valid number");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        private void EditContact(ContactDirectory dir)
        {
            try
            {
                Console.WriteLine("enter first name to edit:");
                string fn = Console.ReadLine();
                Console.WriteLine("enter last name to edit:");
                string ln = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln))
                    throw new ArgumentException("first name and last name cannot be empty");

                dir.EditContact(fn, ln);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        private void DeleteContact(ContactDirectory dir)
        {
            try
            {
                Console.WriteLine("enter first name to delete:");
                string fn = Console.ReadLine();
                Console.WriteLine("enter last name to delete:");
                string ln = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln))
                    throw new ArgumentException("first name and last name cannot be empty");

                dir.DeleteContact(fn, ln);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
    }
}
