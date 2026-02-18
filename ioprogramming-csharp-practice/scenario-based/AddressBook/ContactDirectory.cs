using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AddressBookApp
{
    public class ContactDirectory : IContactRepository
    {
        private readonly List<ContactPerson> contacts = new List<ContactPerson>();
        private readonly object _lock = new object();
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;

        public void InsertContact(ContactPerson person)
        {
            lock (_lock)
            {
                try
                {
                    if (person == null)
                        throw new ArgumentNullException(nameof(person), "Contact person cannot be null");

                    if (contacts.Any(c => c.Equals(person)))
                    {
                        _logger.Log("Duplicate contact detected, cannot add");
                        return;
                    }

                    contacts.Add(person);
                    _logger.Log($"Contact added: {person.FirstName} {person.LastName}");
                }
                catch (ArgumentNullException ex)
                {
                    _logger.LogError("Failed to insert contact", ex);
                    throw new ContactException("Failed to insert contact", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error inserting contact", ex);
                    throw new ContactException("Unexpected error while inserting contact", ex);
                }
            }
        }

        public void SearchByCityOrState(string value)
        {
            lock (_lock)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Search value cannot be empty", nameof(value));

                    var searchResults = contacts.Where(c => c.City == value || c.State == value).ToList();

                    if (searchResults.Count == 0)
                    {
                        _logger.Log($"No persons found in city or state: {value}");
                        return;
                    }

                    _logger.Log($"Found {searchResults.Count} person(s) in {value}");
                    searchResults.ForEach(c =>
                    {
                        c.Display();
                        Console.WriteLine("");
                    });
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError("Search validation failed", ex);
                    throw new ContactException("Search operation failed", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error during search", ex);
                    throw new ContactException("Unexpected error during search", ex);
                }
            }
        }

        public void ViewPersonsByCity(string city)
        {
            lock (_lock)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(city))
                        throw new ArgumentException("City cannot be empty", nameof(city));

                    var cityResults = contacts.Where(c => c.City == city).ToList();

                    if (cityResults.Count == 0)
                    {
                        _logger.Log($"No persons found in city: {city}");
                        return;
                    }

                    _logger.Log($"Displaying {cityResults.Count} person(s) from {city}");
                    cityResults.ForEach(c =>
                    {
                        c.Display();
                        Console.WriteLine("");
                    });
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError("View by city validation failed", ex);
                    throw new ContactException("Failed to view persons by city", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error viewing persons by city", ex);
                    throw new ContactException("Unexpected error viewing persons by city", ex);
                }
            }
        }

        public void ViewPersonsByState(string state)
        {
            lock (_lock)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(state))
                        throw new ArgumentException("State cannot be empty", nameof(state));

                    var stateResults = contacts.Where(c => c.State == state).ToList();

                    if (stateResults.Count == 0)
                    {
                        _logger.Log($"No persons found in state: {state}");
                        return;
                    }

                    _logger.Log($"Displaying {stateResults.Count} person(s) from {state}");
                    stateResults.ForEach(c =>
                    {
                        c.Display();
                        Console.WriteLine("");
                    });
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError("View by state validation failed", ex);
                    throw new ContactException("Failed to view persons by state", ex);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error viewing persons by state", ex);
                    throw new ContactException("Unexpected error viewing persons by state", ex);
                }
            }
        }

        public void EditContact(string firstName, string lastName)
        {
            lock (_lock)
            {
                try
                {
                    if (contacts.Count == 0)
                    {
                        _logger.Log("No contacts available for editing");
                        return;
                    }

                    var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                    if (contact == null)
                    {
                        _logger.Log($"Contact not found: {firstName} {lastName}");
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
                    
                    _logger.Log($"Contact updated: {firstName} {lastName}");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error updating contact", ex);
                    throw new ContactException("Failed to update contact", ex);
                }
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
            lock (_lock)
            {
                try
                {
                    if (contacts.Count == 0)
                    {
                        _logger.Log("No contacts available for deletion");
                        return;
                    }

                    var contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                    if (contact == null)
                    {
                        _logger.Log($"Contact not found for deletion: {firstName} {lastName}");
                        return;
                    }

                    contacts.Remove(contact);
                    _logger.Log($"Contact deleted: {firstName} {lastName}");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error deleting contact", ex);
                    throw new ContactException("Failed to delete contact", ex);
                }
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
            lock (_lock)
            {
                try
                {
                    var sorted = contacts.OrderBy(c => c.FirstName).ToList();
                    contacts.Clear();
                    contacts.AddRange(sorted);
                    _logger.Log("Contacts sorted by first name");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error sorting by first name", ex);
                    throw new ContactException("Failed to sort by first name", ex);
                }
            }
        }

        public void SortByCity()
        {
            lock (_lock)
            {
                try
                {
                    var sorted = contacts.OrderBy(c => c.City).ToList();
                    contacts.Clear();
                    contacts.AddRange(sorted);
                    _logger.Log("Contacts sorted by city");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error sorting by city", ex);
                    throw new ContactException("Failed to sort by city", ex);
                }
            }
        }

        public void SortByState()
        {
            lock (_lock)
            {
                try
                {
                    var sorted = contacts.OrderBy(c => c.State).ToList();
                    contacts.Clear();
                    contacts.AddRange(sorted);
                    _logger.Log("Contacts sorted by state");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error sorting by state", ex);
                    throw new ContactException("Failed to sort by state", ex);
                }
            }
        }

        public void SortByZip()
        {
            lock (_lock)
            {
                try
                {
                    var sorted = contacts.OrderBy(c => c.Zip).ToList();
                    contacts.Clear();
                    contacts.AddRange(sorted);
                    _logger.Log("Contacts sorted by zip");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error sorting by zip", ex);
                    throw new ContactException("Failed to sort by zip", ex);
                }
            }
        }

        public List<ContactPerson> GetAllContacts()
        {
            return new List<ContactPerson>(contacts);
        }
    }
}
