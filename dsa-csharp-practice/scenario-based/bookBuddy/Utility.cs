public class Utility{
    static Book[] books=new Book[100];
    static int bookCount = 0;

    public static void AddABook(Book book)
    {
        if(bookCount<books.Length)
        {
            books[bookCount] = book;
            bookCount++;
            book.Display();
            Console.WriteLine("added this book.");
            Console.WriteLine();
        }
    }
    public static void SortByName(){
        for(int i = 0;i<bookCount-1;i++)
        {
            for(int j = i+1;j<bookCount;j++)
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
        for(int i = 0;i<bookCount-1;i++)
        {
            for(int j = i+1;j<bookCount;j++)
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
        for(int i = 0; i<bookCount; i++)
        {
            books[i].Display();
            Console.WriteLine();
        }
    }
    public static void UpdateBook()
    {
        Console.Write("enter title of book to update: ");
        string searchTitle=Console.ReadLine();
        for(int i=0;i<bookCount;i++)
        {
            if(books[i].title.ToLower()==searchTitle.ToLower())
            {
                Console.Write("enter new title: ");
                books[i].title=Console.ReadLine();
                Console.Write("enter new author: ");
                books[i].author=Console.ReadLine();
                Console.Write("enter new price: ");
                books[i].price=Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("book updated");
                Console.WriteLine();
                return;
            }
        }
        Console.WriteLine("book not found");
        Console.WriteLine();
    }

}
