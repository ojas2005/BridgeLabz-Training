using System;

namespace AddressBookApp.Exceptions
{
    [Serializable]
    public class AddressBookException : Exception
    {
        public AddressBookException() : base() { }
        public AddressBookException(string message) : base(message) { }
        public AddressBookException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
