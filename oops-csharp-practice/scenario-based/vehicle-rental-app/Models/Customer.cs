namespace VehicleRentalApp.Models
{
    public class Customer
    {
        private string customerId;
        private string customerName;
        private string phoneNumber;
        private string emailAddress;
        public Customer(string id,string name,string phone,string email)
        {
            customerId=id;
            customerName=name;
            phoneNumber=phone;
            emailAddress=email;
        }
        public string CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId=value;
            }
        }
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName=value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber=value;
            }
        }
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress=value;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"customer id: {customerId}");
            Console.WriteLine($"customer name: {customerName}");
            Console.WriteLine($"phone: {phoneNumber}");
            Console.WriteLine($"email: {emailAddress}");
        }
    }
}
