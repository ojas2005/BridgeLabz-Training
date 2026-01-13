public class Book : IManager{
    public string title;
    public string author;
    public double price;
    public Book(string title,string author,double price)
    {
        this.title = title;
        this.author=author;
        this.price= price;

    }
    public void Display(){
        Console.WriteLine($"book title is: {title}, book author is: {author},book price is {price}");
        Console.WriteLine();
    }
}