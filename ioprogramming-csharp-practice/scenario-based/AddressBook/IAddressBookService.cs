using System;

namespace AddressBookApp
{
    public interface IAddressBookService
    {
        void CreateAddressBook();
        void UseAddressBook();
        void SearchPersonByCityOrState();
    }
}
