using System;

namespace ExceptionHandlingProblems.Exceptions
{
    //custom exception for invalid age validation
    public class InvalidAgeException : Exception
    {
        //initialize custom exception with message
        public InvalidAgeException(string message) : base(message)
        {
        }

        //default constructor
        public InvalidAgeException() : base("Age must be 18 or above")
        {
        }
    }
}
