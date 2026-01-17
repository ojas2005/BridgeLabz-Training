using BookShelf.Models;
using BookShelf.Services;

namespace BookShelf.Services
{
    public class LibraryManager
    {
        private BookShelf bookShelf;

        public LibraryManager()
        {
            this.bookShelf=new BookShelf();
        }

        public void AddBookToLibrary(string title,string author,string genre,string isbn)
        {
            Book book=new Book(title,author,genre,isbn);
            bookShelf.AddBook(book);
        }

        public void RemoveBookFromLibrary(string title)
        {
            Book book=bookShelf.FindBook(title);
            if(book!=null)
            {
                bookShelf.RemoveBook(book);
            }
            else
            {
                Console.WriteLine($"Book '{title}' not found!");
            }
        }

        public void BorrowBook(string isbn)
        {
            bookShelf.BorrowBook(isbn);
        }

        public void ReturnBook(string isbn)
        {
            bookShelf.ReturnBook(isbn);
        }

        public void DisplayCatalogByGenre(string genre)
        {
            bookShelf.DisplayGenreBooks(genre);
        }

        public void DisplayAllGenres()
        {
            bookShelf.DisplayAllGenres();
        }

        public void DisplayLibraryStats()
        {
            Console.WriteLine("\n ****Library Statistics*****");
            Console.WriteLine($"Total Books: {bookShelf.GetTotalBooks()}");
            Console.WriteLine($"Available Books: {bookShelf.GetAvailableBooks()}");
            Console.WriteLine($"Borrowed Books: {bookShelf.GetTotalBooks()-bookShelf.GetAvailableBooks()}");
        }
    }
}
