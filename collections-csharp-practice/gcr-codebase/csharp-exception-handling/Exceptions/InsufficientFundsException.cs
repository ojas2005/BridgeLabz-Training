using System;

namespace ExceptionHandlingProblems.Exceptions
{
    //custom exception for insufficient balance in bank account
    public class InsufficientFundsException : Exception
    {
        //initialize custom exception with message
        public InsufficientFundsException(string message) : base(message)
        {
        }

        //default constructor
        public InsufficientFundsException() : base("Insufficient balance for this transaction")
        {
        }
    }
}
