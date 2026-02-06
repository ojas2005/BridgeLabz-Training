using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    public class ContactDirectory
    {
        private List<ContactPerson> contacts = new List<ContactPerson>();

        public void InsertContact(ContactPerson person)
        {
            try
            {
                if(person == null)
                    throw new ArgumentNullException(nameof(person));

                if(contacts.Any(c => c.Equals(person)))
                {
                    Console.WriteLine("duplicate contact, cannot add");
                    return;
                }

                contacts.Add(person);
                Console.WriteLine("contact added to address book");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public void SearchByCityOrState(string value)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("search value cannot be empty");

                var searchResults = contacts.Where(c => c.City == value || c.State == value).ToList();

                if(searchResults.Count == 0)
                {
                    Console.WriteLine("no person found in given city or state");
                    return;
                }

                searchResults.ForEach(c =>
                {
                    c.Display();
                    Console.WriteLine("");
                });
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public void ViewPersonsByCity(string city)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(city))
                    throw new ArgumentException("city cannot be empty");

                var cityResults = contacts.Where(c => c.City == city).ToList();

                if(cityResults.Count == 0)
                {
                    Console.WriteLine("no persons found in this city");
                    return;
                }

                cityResults.ForEach(c =>
                {
                    c.Display();
                    Console.WriteLine("");
                });
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public void ViewPersonsByState(string state)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(state))
                    throw new ArgumentException("state cannot be empty");

                var stateResults = contacts.Where(c => c.State == state).ToList();

                if(stateResults.Count == 0)
                {
                    Console.WriteLine("no persons found in this state");
                    return;
                }

                stateResults.ForEach(c =>
                {
                    c.Display();
                    Console.WriteLine("");
                });
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public void EditContact(string firstName, string lastName)
        {
            try
            {
                if(contacts.Count == 0)
                {
                    Console.WriteLine("no contacts available");
                    return;
                }

                var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                if(contact == null)
                {
                    Console.WriteLine("contact not found");
                    return;
                }

                Console.WriteLine("enter new address:");
                contact.Address = Console.ReadLine();
                Console.WriteLine("enter new city:");
                contact.City = Console.ReadLine();
                Console.WriteLine("enter new state:");
                contact.State = Console.ReadLine();
                Console.WriteLine("enter new zip:");
                contact.Zip = Console.ReadLine();
                Console.WriteLine("enter new phone number:");
                contact.Phone = Console.ReadLine();
                Console.WriteLine("enter new email:");
                contact.Email = Console.ReadLine();
                Console.WriteLine("contact updated successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error updating contact: {ex.Message}");
            }
        }

        public int CountByCity(string city)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(city))
                    return 0;

                return contacts.Count(c => c.City == city);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error counting by city: {ex.Message}");
                return 0;
            }
        }

        public int CountByState(string state)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(state))
                    return 0;

                return contacts.Count(c => c.State == state);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error counting by state: {ex.Message}");
                return 0;
            }
        }

        public void DeleteContact(string firstName, string lastName)
        {
            try
            {
                if(contacts.Count == 0)
                {
                    Console.WriteLine("no contacts available");
                    return;
                }

                var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                if(contact == null)
                {
                    Console.WriteLine("contact not found");
                    return;
                }

                contacts.Remove(contact);
                Console.WriteLine("contact deleted successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error deleting contact: {ex.Message}");
            }
        }

        public void DisplayAllContacts()
        {
            if(contacts.Count == 0)
            {
                Console.WriteLine("no contacts available");
                return;
            }

            contacts.ForEach(c =>
            {
                Console.WriteLine("");
                c.Display();
            });
        }

        public void SortByFirstName()
        {
            try
            {
                var sorted = contacts.OrderBy(c => c.FirstName).ToList();
                contacts.Clear();
                contacts.AddRange(sorted);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error sorting by first name: {ex.Message}");
            }
        }

        public void SortByCity()
        {
            try
            {
                var sorted = contacts.OrderBy(c => c.City).ToList();
                contacts.Clear();
                contacts.AddRange(sorted);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error sorting by city: {ex.Message}");
            }
        }

        public void SortByState()
        {
            try
            {
                var sorted = contacts.OrderBy(c => c.State).ToList();
                contacts.Clear();
                contacts.AddRange(sorted);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error sorting by state: {ex.Message}");
            }
        }

        public void SortByZip()
        {
            try
            {
                var sorted = contacts.OrderBy(c => c.Zip).ToList();
                contacts.Clear();
                contacts.AddRange(sorted);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error sorting by zip: {ex.Message}");
            }
        }

        public List<ContactPerson> GetAllContacts()
        {
            return new List<ContactPerson>(contacts);
        }
    }
}
