using System;

class Book
{
    private string title;
    private string author;
    private double price;
    public Books()
    {
        title = "The brief history of time";
        author = "Stephen Hawkings";
        price = 250.0;
    }
    public Books(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }
    public void DisplayDetails()
    {
        Console.WriteLine("book title is" + title);
        Console.WriteLine("book author is " + author);
        Console.WriteLine("book price is " + price);
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new Book();
        Console.WriteLine("Default Book Details:");
        book1.DisplayDetails();
        Console.WriteLine();
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
       Console.Write("Enter author name: ");
        string author = Console.ReadLine();
        Console.Write("Enter price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        Book book2 = new Book(title, author, price);
        Console.WriteLine("\nEntered Book Details:");
        book2.DisplayDetails();
    }
}
