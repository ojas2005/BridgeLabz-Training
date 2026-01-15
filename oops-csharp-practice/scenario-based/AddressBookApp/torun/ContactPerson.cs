namespace AddressBookApp
{
    public class ContactPerson
    {
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string Phone;
        public string Email;

        public ContactPerson(string firstName, string lastName, string address,string city, string state, string zip,string phone, string email)
        {
            FirstName=firstName;
            LastName=lastName;
            Address=address;
            City=city;
            State=state;
            Zip=zip;
            Phone=phone;
            Email=email;
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
