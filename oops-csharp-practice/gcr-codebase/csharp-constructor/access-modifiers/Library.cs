using System;
class library
    {
        static void Main(string[] args)
        {
            Library b1 = new Library();
            Library b2 = new Library("ARE463", "the heat of lave", "mount ain");
            ELibrary e1 = new ELibrary();

            b1.Display();
            b2.Display();
            e1.Display();
        }
    }
    public class Library
    {
        // creating the atributes
        public string ISBN;
        protected string title;
        private string author;
        // constructors
        public Library()
        {
            this.ISBN = "12323";
            this.title = "C# book";
            this.author = "demo author";
        }
        public Library(string ISBN, string title, string author)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public string GetAuthor()
        {
            return author;
        }
        public void Display()
        {
            string auth = GetAuthor();
            Console.WriteLine($"ISBN of this book titled {title} by {auth} is {ISBN}");
        }
    }
    public class ELibrary : Library
    {
        public ELibrary() : base(1232,"demo c#","c#");
        public void Display()
        {
            string a = GetAuthor();
            Console.WriteLine($"ISBN of this ebook titled {title} by {a} is {ISBN}");
        }
    }
