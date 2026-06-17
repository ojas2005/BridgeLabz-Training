using System;

namespace AddressBookApp
{

    [Serializable]
    public class ContactPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ContactPerson(string firstName, string lastName, string address, string city, string state, string zip, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First name and last name cannot be empty");
            
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            ContactPerson other = (ContactPerson)obj;
            return this.FirstName == other.FirstName && this.LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public void Display()
        {
            Console.WriteLine($"name: {FirstName} {LastName}");
            Console.WriteLine($"address: {Address}, {City}, {State} - {Zip}");
            Console.WriteLine($"phone: {Phone}");
            Console.WriteLine($"email: {Email}");
        }
    }
}
