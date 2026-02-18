using System;

namespace AddressBookApp
{

    public interface IDataValidator
    {
        bool ValidateContactPerson(string firstName, string lastName, string address, string city, string state, string zip, string phone, string email);
        bool ValidateCity(string city);
        bool ValidateState(string state);
        bool ValidateEmail(string email);
        bool ValidatePhone(string phone);
    }
}
