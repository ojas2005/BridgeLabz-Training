using System;
using System.Text.RegularExpressions;

namespace AddressBookApp
{
    public class DataValidator : IDataValidator
    {
        //Email validation pattern
        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        //Phone validation pattern
        private const string PhonePattern = @"^\d{10}$|^\d{3}-\d{3}-\d{4}$|^\(\d{3}\)\s?\d{3}-\d{4}$";

        public bool ValidateContactPerson(string firstName, string lastName, string address, 
            string city, string state, string zip, string phone, string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                    throw new DataValidationException("First name and last name are required");

                if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(state))
                    throw new DataValidationException("City and state are required");

                if (!string.IsNullOrWhiteSpace(email) && !ValidateEmail(email))
                    throw new DataValidationException("Invalid email format");

                if (!string.IsNullOrWhiteSpace(phone) && !ValidatePhone(phone))
                    throw new DataValidationException("Invalid phone number format");

                return true;
            }
            catch (DataValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataValidationException("Error validating contact person", ex);
            }
        }

        public bool ValidateCity(string city)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(city);
            }
            catch (Exception ex)
            {
                throw new DataValidationException("Error validating city", ex);
            }
        }

        public bool ValidateState(string state)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(state);
            }
            catch (Exception ex)
            {
                throw new DataValidationException("Error validating state", ex);
            }
        }

        public bool ValidateEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return true;

                return Regex.IsMatch(email, EmailPattern);
            }
            catch (Exception ex)
            {
                throw new DataValidationException("Error validating email", ex);
            }
        }

        public bool ValidatePhone(string phone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phone))
                    return true;

                return Regex.IsMatch(phone, PhonePattern);
            }
            catch (Exception ex)
            {
                throw new DataValidationException("Error validating phone", ex);
            }
        }
    }
}
