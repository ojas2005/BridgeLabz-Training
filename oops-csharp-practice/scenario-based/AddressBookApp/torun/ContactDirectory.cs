namespace AddressBookApp
{
    public class ContactDirectory
    {
        private ContactPerson[] contacts=new ContactPerson[100];
        private int count=0;
        public void InsertContact(ContactPerson person)
        {
            if (count<contacts.Length)
            {
                contacts[count++]=person;
                Console.WriteLine("contact added to address book");
            }
            else
            {
                Console.WriteLine("address book is full");
            }
        }

        public void DisplayAllContacts()
        {
            if (count==0)
            {
                Console.WriteLine("no contacts available");
                return;
            }

            for (int i=0;i<count;i++)
            {
                Console.WriteLine("");
                contacts[i].Display();
            }
        }
    }
}
