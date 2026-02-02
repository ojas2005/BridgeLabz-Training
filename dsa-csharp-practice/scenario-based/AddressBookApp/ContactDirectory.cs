namespace AddressBookApp
{
    public class ContactDirectory
    {
        private LinkedList contacts = new LinkedList();
        private int count = 0;
        public void InsertContact(ContactPerson person)
        {
            for(int i=0;i<count;i++)
            {
                if(contacts.GetAt(i).Equals(person))
                {
                    Console.WriteLine("duplicate contact,cannot add");
                    return;
                }
            }
            contacts.Add(person);
            count++;
            Console.WriteLine("contact added to address book");
        }
        public void SearchByCityOrState(string value)
        {
            bool found=false;
            for(int i=0;i<count;i++)
            {
                ContactPerson contact = contacts.GetAt(i);
                if(contact.City==value || contact.State==value)
                {
                    contact.Display();
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
                ContactPerson contact = contacts.GetAt(i);
                if(contact.City==city)
                {
                    contact.Display();
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
                ContactPerson contact = contacts.GetAt(i);
                if(contact.State==state)
                {
                    contact.Display();
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
                ContactPerson contact = contacts.GetAt(i);
                if (contact.FirstName==firstName && contact.LastName==lastName)
                {
                    Console.WriteLine("enter new address:");
                    contact.Address=Console.ReadLine();
                    Console.WriteLine("enter new city:");
                    contact.City=Console.ReadLine();
                    Console.WriteLine("enter new state:");
                    contact.State=Console.ReadLine();
                    Console.WriteLine("enter new zip:");
                    contact.Zip=Console.ReadLine();
                    Console.WriteLine("enter new phone number:");
                    contact.Phone=Console.ReadLine();
                    Console.WriteLine("enter new email:");
                    contact.Email=Console.ReadLine();
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
                if(contacts.GetAt(i).City==city)
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
                if(contacts.GetAt(i).State==state)
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
                ContactPerson contact = contacts.GetAt(i);
                if(contact.FirstName==firstName && contact.LastName==lastName)
                {
                    contacts.RemoveAt(i);
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
                contacts.GetAt(i).Display();
            }
        }
        public void SortByFirstName()
        {
            ContactPerson[] arr = contacts.ToArray();
            for(int i=0;i<count-1;i++)
            {
                for(int j=i+1;j<count;j++)
                {
                    if(string.Compare(arr[i].FirstName,arr[j].FirstName)>0)
                    {
                        ContactPerson temp=arr[i];
                        arr[i]=arr[j];
                        arr[j]=temp;
                    }
                }
            }
            contacts.Clear();
            for(int i=0;i<arr.Length;i++)
            {
                contacts.Add(arr[i]);
            }
        }
        public void SortByCity()
        {
            ContactPerson[] arr = contacts.ToArray();
            for(int i=0;i<count-1;i++)
            {
                for(int j=i+1;j<count;j++)
                {
                    if(string.Compare(arr[i].City,arr[j].City)>0)
                    {
                        ContactPerson temp=arr[i];
                        arr[i]=arr[j];
                        arr[j]=temp;
                    }
                }
            }
            contacts.Clear();
            for(int i=0;i<arr.Length;i++)
            {
                contacts.Add(arr[i]);
            }
        }
        public void SortByState()
        {
            ContactPerson[] arr = contacts.ToArray();
            for(int i=0;i<count-1;i++)
            {
                for(int j=i+1;j<count;j++)
                {
                    if(string.Compare(arr[i].State,arr[j].State)>0)
                    {
                        ContactPerson temp=arr[i];
                        arr[i]=arr[j];
                        arr[j]=temp;
                    }
                }
            }
            contacts.Clear();
            for(int i=0;i<arr.Length;i++)
            {
                contacts.Add(arr[i]);
            }
        }
        public void SortByZip()
        {
            ContactPerson[] arr = contacts.ToArray();
            for(int i=0;i<count-1;i++)
            {
                for(int j=i+1;j<count;j++)
                {
                    if(string.Compare(arr[i].Zip,arr[j].Zip)>0)
                    {
                        ContactPerson temp=arr[i];
                        arr[i]=arr[j];
                        arr[j]=temp;
                    }
                }
            }
            contacts.Clear();
            for(int i=0;i<arr.Length;i++)
            {
                contacts.Add(arr[i]);
            }
        }




    }

}
