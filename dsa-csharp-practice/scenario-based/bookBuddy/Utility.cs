public class Utility{
    static List<Book> books=new List<Book>();
    public static void AddABook(Book book)
    {
        books.Add(book);
        book.Display();
        Console.WriteLine("added this book.");
        Console.WriteLine();
    }
    public static void SortByName(){
        for(int i = 0;i<books.Count-1;i++)
        {
            for(int j = i+1;j<books.Count-1;j++)
            {
                if(string.Compare(books[i].title,books[j].title)>0)
                {
                    Book temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }
        Console.WriteLine("we have sorted the books by book title");
    }
    public static void SortByAuthor(){
        for(int i = 0;i<books.Count-1;i++)
        {
            for(int j = i+1;j<books.Count;j++)
            {
                if(string.Compare(books[i].author,books[j].author)>0)
                {
                    Book temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }
        Console.WriteLine("we have sorted the books by book title");
    }
    public static void ShowAllBooks()
    {
        foreach(Book book in books)
        {
            book.Display();
            Console.WriteLine();
        }
    }
}