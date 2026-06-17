using System.Collections.Generic;

namespace AddressBookApp
{
    public interface IFileIO
    {
        void SaveContacts(List<ContactPerson> contacts, string filename);
        List<ContactPerson> LoadContacts(string filename);
    }
}
