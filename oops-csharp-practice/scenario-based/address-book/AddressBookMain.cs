internal class AddressBookMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book Program");
        ContactService service = new ContactService();
        service.AppendContact();
    }
}
