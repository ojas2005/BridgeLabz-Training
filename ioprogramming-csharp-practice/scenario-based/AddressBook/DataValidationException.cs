using System;

namespace AddressBookApp
{
    [Serializable]
    public class DataValidationException : Exception
    {
        public DataValidationException() : base() { }
        public DataValidationException(string message) : base(message) { }
        public DataValidationException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
