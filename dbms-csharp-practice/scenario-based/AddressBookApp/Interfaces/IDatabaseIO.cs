using System.Collections.Generic;

namespace AddressBookApp.Interfaces
{
    public interface IDatabaseIO
    {
        void SaveContacts(List<ContactPerson> contacts, string databasePath);
        List<ContactPerson> LoadContacts(string databasePath);
        void InsertContact(ContactPerson contact, string databasePath);
        void DeleteContact(string firstName, string lastName, string databasePath);
        List<ContactPerson> GetContactsByCity(string city, string databasePath);
        List<ContactPerson> GetContactsByState(string state, string databasePath);
    }
}
