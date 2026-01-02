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
        Console.WriteLine($"book title is {title} ");
        Console.WriteLine($"book author is {author} ");
        Console.WriteLine($"book Price is {price}");
    }
}
