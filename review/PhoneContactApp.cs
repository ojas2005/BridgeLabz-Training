using System;
class PhoneContactApp{
    static int totalContacts=0;
    static string[,] contact = new string[100,4];
    static void Main()
    {
        

        
    while(true)
    {
        Console.WriteLine("Enter the service you want to choose:");
        Console.WriteLine("press 1 for add a contact");
        Console.WriteLine("press 2 to update the contact");
        Console.WriteLine("press 3 to delete a contact");
        Console.WriteLine("press 4 for search a contact");
        Console.WriteLine("press 6 to show all contacts");
        Console.WriteLine("press 7 to exit");

        int choice = int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1: 
                Console.WriteLine("Enter name of contact");
                contact[totalContacts,0] = Console.ReadLine();
                Console.WriteLine("Enter email of the person");
                contact[totalContacts,1] = Console.ReadLine();
                Console.WriteLine("Enter city of the person");
                contact[totalContacts,2] = Console.ReadLine();
                Console.WriteLine("Enter the phone number");
                contact[totalContacts,3] = Console.ReadLine();
                totalContacts++;
                continue;
            case 2:
                Console.WriteLine("enter the contact you want to update");
                string name = Console.ReadLine();
                int index = FindIndex(name,contact);
                if(index!=-1)
                {
                    Console.WriteLine("enter updated name");
                    contact[index,0] = Console.ReadLine();
                    Console.WriteLine("enter email of the person");
                    contact[index,1] = Console.ReadLine();
                    Console.WriteLine("enter city of the person");
                    contact[index,2] = Console.ReadLine();
                    Console.WriteLine("enter the phone number");
                    contact[index,3] = Console.ReadLine();
                }
                else{
                    Console.WriteLine("Cannot find the contact");
                }
                continue;
            case 3:
                Console.WriteLine("enter the contact you want to delete");
                string na = Console.ReadLine();
                int ind = FindIndex(na,contact);
                if(ind!=-1)
                {
                    contact[ind,0] = null;
                    contact[ind,1]= null;
                    contact[ind,2]= null;
                    contact[ind,3] = null;
                }
                continue;
            case 4:
                Console.WriteLine("press 1 to search by name");
                Console.WriteLine("press 2 to search by email");
                Console.WriteLine("press 3 to search by city");
                Console.WriteLine("press 4 to search by phone");
                int ch = int.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1: 
                        Console.WriteLine("enter the name(partial accepted)");
                        string part = Console.ReadLine();

                        for(int i=0;i<totalContacts;i++)
                        {
                            string temp = contact[i,0];
                            if(temp.ToLower().Contains(part.ToLower()))

                            {
                                Console.WriteLine($"name-{contact[i,0]},email-{contact[i,1]},city-{contact[i,2]},phone-{contact[i,3]}");
                            }
                        }
                        continue;
                    case 2:
                        Console.WriteLine("enter the email(partial accepted)");
                            string p = Console.ReadLine();
                            p = p.ToLower();
                            

                            for(int i=0;i<totalContacts;i++)
                            {
                                string t = contact[i,1];
                                t= t.ToLower();
                                if(t.Contains(p))
                                {
                                    Console.WriteLine($"name-{contact[i,0]},email-{contact[i,1]},city-{contact[i,2]},phone-{contact[i,3]}");
                                }
                            }
                            continue;
                    case 3:
                        Console.WriteLine("enter the city(partial accepted)");
                        string partf = Console.ReadLine();
                        partf = partf.ToLower();
                        

                        for(int i=0;i<totalContacts;i++)
                        {
                            string te = contact[i,2];
                            if(te.ToLower().Contains(partf))
                            {
                                Console.WriteLine($"name-{contact[i,0]},email-{contact[i,1]},city-{contact[i,2]},phone-{contact[i,3]}");
                            }
                        }
                        continue;
                    case 4:
                        Console.WriteLine("enter the number(partial accepted)");
                        string par = Console.ReadLine();
                        par = par.ToLower();
                        

                        for(int i=0;i<totalContacts;i++)
                        {
                            string nm = contact[i,3];
                            if(nm.ToLower().Contains(par))
                            {
                                Console.WriteLine($"name-{contact[i,0]},email-{contact[i,1]},city-{contact[i,2]},phone-{contact[i,3]}");
                            }
                        }
                        continue;
                    case 5:
                        Console.WriteLine("invalid input");
                        return;
            
                
                }
                continue;

            case 6:
                for(int i = 0;i<totalContacts;i++)
                {
                    Console.WriteLine($"name-{contact[i,0]},email-{contact[i,1]},city-{contact[i,2]},phone-{contact[i,3]}");
                }
                continue;
            case 7:
                return;
        }
    }

    }
    static int FindIndex(string name,string[,] contacts)
        {
            for (int i=0;i<totalContacts;i++)
                {
                    if (contacts[i,0].ToLower().Contains(name))
                    return i;
                }
                return -1;
            }
}
