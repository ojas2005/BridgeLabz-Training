using BookShelf.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bookshelf Library Management System");

        LibraryManager library = new LibraryManager();

        Console.WriteLine("Adding books to library");
        library.AddBookToLibrary("Wings of Fire","A. P. J. Abdul Kalam","Biography","978-8173711466");
        library.AddBookToLibrary("The Discovery of India","Jawaharlal Nehru","History","978-0143031031");
        library.AddBookToLibrary("India After Gandhi","Ramachandra Guha","History","978-0330505543");
        library.AddBookToLibrary("The White Tiger","Aravind Adiga","Fiction","978-8172238476");
        library.AddBookToLibrary("God of Small Things","Arundhati Roy","Fiction","978-0006550686");
        library.AddBookToLibrary("The Guide","R. K. Narayan","Fiction","978-8185986173");
        library.AddBookToLibrary("My Experiments with Truth","Mahatma Gandhi","Autobiography","978-8172291235");
        library.AddBookToLibrary("Ignited Minds","A. P. J. Abdul Kalam","Inspirational","978-0143424123");

        Console.WriteLine("Attempting duplicate book");
        library.AddBookToLibrary("Wings of Fire","A. P. J. Abdul Kalam","Biography","978-8173711466");

        library.DisplayAllGenres();

        Console.WriteLine("Fiction books");
        library.DisplayCatalogByGenre("Fiction");

        Console.WriteLine("History books");
        library.DisplayCatalogByGenre("History");

        Console.WriteLine("Biography books");
        library.DisplayCatalogByGenre("Biography");

        Console.WriteLine("Borrowing books");
        library.BorrowBook("978-8173711466");
        library.BorrowBook("978-8185986173");
        library.BorrowBook("978-0143031031");

        Console.WriteLine("Attempting to borrow already borrowed book");
        library.BorrowBook("978-8173711466");

        library.DisplayLibraryStats();

        Console.WriteLine("Returning books");
        library.ReturnBook("978-8173711466");
        library.ReturnBook("978-8185986173");

        library.DisplayLibraryStats();

        Console.WriteLine("Removing books");
        library.RemoveBookFromLibrary("The Guide");
        library.RemoveBookFromLibrary("India After Gandhi");

        Console.WriteLine("Final library state");
        library.DisplayLibraryStats();
        library.DisplayAllGenres();

        Console.WriteLine("Program execution completed successfully");
    }
}
