using System;

namespace AddressBookApp.Interfaces
{
    public interface IAddressBookService
    {
        void CreateAddressBook();
        void UseAddressBook();
        void SearchPersonByCityOrState();
    }
}
