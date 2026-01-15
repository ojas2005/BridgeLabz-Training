namespace AddressBookApp
{
    public class ContactDirectory
    {
        private ContactPerson[] contacts=new ContactPerson[100];
        private int count=0;
        public void InsertContact(ContactPerson person)
        {
            for(int i=0;i<count;i++)
            {
                if(contacts[i].Equals(person))
                {
                    Console.WriteLine("duplicate contact,cannot add");
                    return;
                }
            }
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
        public void SearchByCityOrState(string value)
        {
            bool found=false;
            for(int i=0;i<count;i++)
            {
                if(contacts[i].City==value || contacts[i].State==value)
                {
                    contacts[i].Display();
                    Console.WriteLine("");
                    found=true;
                }
            }
            if(!found)
            {
                Console.WriteLine("no person found in given city or state");
            }
        }
        public void ViewPersonsByCity(string city)
        {
            bool found=false;
            for(int i=0;i<count;i++)
            {
                if(contacts[i].City==city)
                {
                    contacts[i].Display();
                    Console.WriteLine("");
                    found=true;
                }
            }
            if(!found)
            {
                Console.WriteLine("no persons found in this city");
            }
        }
        public void ViewPersonsByState(string state)
        {
            bool found=false;
            for(int i=0;i<count;i++)
            {
                if(contacts[i].State==state)
                {
                    contacts[i].Display();
                    Console.WriteLine("");
                    found=true;
                }
            }
            if(!found)
            {
                Console.WriteLine("no persons found in this state");
            }
        }




        public void EditContact(string firstName,string lastName)
        {
            if(count==0)
            {
                Console.WriteLine("no contacts available");
                return;
            }
            for(int i=0;i<count;i++)
            {
                if (contacts[i].FirstName==firstName && contacts[i].LastName==lastName)
                {
                    Console.WriteLine("enter new address:");
                    contacts[i].Address=Console.ReadLine();
                    Console.WriteLine("enter new city:");
                    contacts[i].City=Console.ReadLine();
                    Console.WriteLine("enter new state:");
                    contacts[i].State=Console.ReadLine();
                    Console.WriteLine("enter new zip:");
                    contacts[i].Zip=Console.ReadLine();
                    Console.WriteLine("enter new phone number:");
                    contacts[i].Phone=Console.ReadLine();
                    Console.WriteLine("enter new email:");
                    contacts[i].Email=Console.ReadLine();
                    Console.WriteLine("contact updated successfully");
                    return;
                }
            }
            Console.WriteLine("contact not found");
        }
        public int CountByCity(string city)
        {
            int c=0;
            for(int i=0;i<count;i++)
            {
                if(contacts[i].City==city)
                {
                    c++;
                }
            }
            return c;
        }
        public int CountByState(string state)
        {
            int c=0;
            for(int i=0;i<count;i++)
            {
                if(contacts[i].State==state)
                {
                    c++;
                }
            }
            return c;
}



        public void DeleteContact(string firstName,string lastName)
        {
            if(count==0)
            {
                Console.WriteLine("no contacts available");
                return;
            }
            for(int i=0;i<count;i++)
            {
                if(contacts[i].FirstName==firstName && contacts[i].LastName==lastName)
                {
                    for(int j=i;j<count-1;j++)
                    {
                        contacts[j]=contacts[j+1];
                    }
                    contacts[count-1]=null;
                    count--;
                    Console.WriteLine("contact deleted successfully");
                    return;
                }
            }
            Console.WriteLine("contact not found");
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
