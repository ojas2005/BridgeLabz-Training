using System;

class Book
{
    private string title;
    private string author;
    private double price;
    public Book(string title, string author, double price)
    {
       this.title = title;
       this.author = author;
       this.price = price;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Book title {title} ");
        Console.WriteLine($"Book author {author} ");
        Console.WriteLine($"Book Price {price}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter author name: ");
        string author = Console.ReadLine();

        Console.Write("Enter price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Book b = new Book(title, author, price);
        b.DisplayDetails();
    }
}
