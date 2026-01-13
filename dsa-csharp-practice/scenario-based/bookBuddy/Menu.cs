using System;

public class Menu
{
    public static void ShowMainMenu()
    {
        
        while(true)
        {
            Console.WriteLine("bookbuddy menu");
            Console.WriteLine("press 1 to add a book");
            Console.WriteLine("press 2 to sort books by title");
            Console.WriteLine("press 3 to sort books by author");
            Console.WriteLine("press 4 to show all books");
            Console.WriteLine("press 6 to exit");
            Console.WriteLine();
            Console.Write("enter your choice: ");
            int choice= int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    addBook();
                    Console.Clear();
                    break;
                case 2:
                    Utility.SortByName();
                    Utility.ShowAllBooks();
                    break;
                case 3:
                    Utility.SortByAuthor();
                    Utility.ShowAllBooks();
                    break;
                case 4:
                    Utility.ShowAllBooks();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("enter a valid choice");
                    break;
            }
            Console.WriteLine();
        }
    }
    static void addBook()
    {
        Console.Write("enter book title:");
        string title=Console.ReadLine();
        Console.Write("enter book author:");
        string author=Console.ReadLine();
        Console.Write("enter book price:");
        double price=Convert.ToDouble(Console.ReadLine());
        Book book=new Book(title,author,price);
        Utility.AddABook(book);
    }
}
