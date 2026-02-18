using System;

namespace AddressBookApp
{
    [Serializable]
    public class ContactException : Exception
    {
        public ContactException() : base() { }
        public ContactException(string message) : base(message) { }
        public ContactException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
