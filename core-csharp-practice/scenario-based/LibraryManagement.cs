using System;
class LibraryManagement{

    static void SearchBookByTitle(string partialTitle,string[,] booksDetails)
    {
        bool found = false;
        for(int i = 0;i<booksDetails.GetLength(0);i++)
        {
            if(booksDetails[i,0].IndexOf(partialTitle,StringComparison.OrdinalIgnoreCase)>=0){
                Console.WriteLine($"Found the Book,Book number {i+1} from the start with title {booksDetails[i,0]},by author {booksDetails[i,1]}, Book status:- {booksDetails[i,2]}");
                found = true;
            }
            
        }
        if(found==false)
            {
                Console.WriteLine("Couldn't find the book");
            }
    }
    static void TakeOutBook(string title,string[,] booksDetails)
    {
        for(int i = 0;i<booksDetails.GetLength(0);i++)
        {
            if(title.Equals(booksDetails[i,0],StringComparison.OrdinalIgnoreCase))
            {
                if(booksDetails[i,2]=="Not Available")
                {
                    Console.WriteLine("Book is not available as its unavailable");
                    return;

                }
                else{
                    Console.WriteLine("You have checked out this book");
                    booksDetails[i,2] = "Not Available";
                    return;
                }
            }
        }
    }

    static string[,] StoreBook(string[,] bookDetails)
    {
        int newLen = bookDetails.GetLength(0)+1;
        string[,] temp = new string[newLen,3];
        for(int i = 0;i<bookDetails.GetLength(0);i++)
        {
            for(int j = 0;j<bookDetails.GetLength(1);j++)
            {
                temp[i,j] = bookDetails[i,j];
            }
        }
        Console.WriteLine("Enter book title");
        temp[newLen-1,0] = Console.ReadLine();
        Console.WriteLine("Enter book's author name");
        temp[newLen-1,1] = Console.ReadLine();
        Console.WriteLine("Enter book's availability status");
        temp[newLen-1,2] = Console.ReadLine();
        
        Console.WriteLine("Your book has been stored");
        Console.WriteLine($"{temp[newLen-1,0]} by {temp[newLen-1,1]} with status: {temp[newLen-1,2]}");
        return temp;



    }
    static void DisplayAllBooksDetails(string[,] booksDetails)
    {
        for(int i = 0;i<booksDetails.GetLength(0);i++)
        {
            Console.WriteLine($"Book {i+1} details");
            Console.WriteLine($"'{booksDetails[i,0]}' by '{booksDetails[i,1]}'. Book status: {booksDetails[i,2]}");
        }
    }
    static void ChangeStatus(string title,string[,] booksDetails)
    {
         for(int i = 0;i<booksDetails.GetLength(0);i++)
        {
            if(title.Equals(booksDetails[i,0],StringComparison.OrdinalIgnoreCase)){
                if(booksDetails[i,2]=="Available")
                {
                    booksDetails[i,2]="Not Available";
                }
                else{
                    booksDetails[i,2] = "Available";
                }

            }
        }
    }
    static void Main()
    {
        int password = 3243234;
        Console.WriteLine("Enter number of books");
        int numberOfBooks = int.Parse(Console.ReadLine());
        string[,] booksDetails = new string[numberOfBooks,3]; //title author and status as 3 parameters per book.
        for(int i = 0;i<numberOfBooks;i++){
            Console.WriteLine("Enter book title");
            booksDetails[i,0] = Console.ReadLine(); //book title.
            Console.WriteLine("Enter book's author name");
            booksDetails[i,1] = Console.ReadLine(); //book author name.
            Console.WriteLine("Enter book's availability status");
            booksDetails[i,2] = Console.ReadLine(); //book availability Status.
        }
            Console.WriteLine("Are you a user or admin? If Admin enter 45,If user press 40");
            int userAdmin = int.Parse(Console.ReadLine());
            if(userAdmin==45)
            {
                Console.WriteLine("Enter admin password:-");
                int adminPass = int.Parse(Console.ReadLine());
                if(adminPass==password)
                {
            
                    Console.WriteLine("-----------------------------Menu-------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Choose the Service you want to use");
                    Console.WriteLine("Enter 1 to Search a Book");
                    Console.WriteLine("Enter 2 to Store a Book");
                    Console.WriteLine("Enter 3 to Taking Out a book");
                    Console.WriteLine("Enter 4 to Display all book's details");
                    Console.WriteLine("Enter 5 to Change a book's availability status");
                    Console.WriteLine("Enter 'q' to Exit the Menu");


                while(true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Select a service you want to use");
                    int choice = int.Parse(Console.ReadLine());

                    switch(choice){
                        case 1: 
                            Console.WriteLine("Enter book title(Partial titles accepted)");
                            string partialTitle = Console.ReadLine();
                            SearchBookByTitle(partialTitle,booksDetails);
                            continue;
                            
                        
                        case 2: 
                            booksDetails= StoreBook(booksDetails);
                            continue;
                            
                        
                        case 3:
                            Console.WriteLine("Enter book's title which you want to take out");
                            string title = Console.ReadLine();
                            TakeOutBook(title,booksDetails);
                            continue;
                            
                        case 4:
                            Console.WriteLine("Enter book title(Partial titles accepted)");
                            DisplayAllBooksDetails(booksDetails);
                            continue;
                        
                        case 5:
                            Console.WriteLine("Enter book title");
                            string titleToChange = Console.ReadLine();
                            ChangeStatus(titleToChange,booksDetails);
                            continue;

                            
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                    }
                    
                }
            }

            else if(userAdmin==40){
                    Console.WriteLine("-----------------------------Menu-------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Choose the Service you want to use");
                    Console.WriteLine("Enter 1 to Search a Book");
                    Console.WriteLine("Enter 2 to return a Book");
                    Console.WriteLine("Enter 3 to rent a book");
                    Console.WriteLine("Enter 4 to Display All book's details");
                    Console.WriteLine("Enter 'q' to Exit the Menu");

                    while(true)
                    {
                    Console.WriteLine("");
                    Console.WriteLine("Select a service you want to use");
                    int choice = int.Parse(Console.ReadLine());

                    switch(choice){
                        case 1: 
                            Console.WriteLine("Enter book title(Partial titles accepted)");
                            string partialTitle = Console.ReadLine();
                            SearchBookByTitle(partialTitle,booksDetails);
                            continue;
                            
                        
                        case 2: 
                            booksDetails= StoreBook(booksDetails);
                            continue;
                            
                        
                        case 3:
                            Console.WriteLine("Enter book's title which you want to rent");
                            string title = Console.ReadLine();
                            TakeOutBook(title,booksDetails);
                            continue;
                            
                        case 4:
                            DisplayAllBooksDetails(booksDetails);
                            continue;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }

                }
            }
            else{
                Console.WriteLine("Invalid Choice");
            }
        }
    }