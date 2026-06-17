using System;
using System.Collections.Generic;

namespace AddressBookApp
{

    public interface IContactRepository
    {
        void InsertContact(ContactPerson person);
        void DeleteContact(string firstName, string lastName);
        void EditContact(string firstName, string lastName);
        void SearchByCityOrState(string value);
        void ViewPersonsByCity(string city);
        void ViewPersonsByState(string state);
        int CountByCity(string city);
        int CountByState(string state);
        void DisplayAllContacts();
        void SortByFirstName();
        void SortByCity();
        void SortByState();
        void SortByZip();
        List<ContactPerson> GetAllContacts();
    }
}
