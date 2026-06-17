using BookShelf.DataStructures;
using BookShelf.Interfaces;
using BookShelf.Models;

namespace BookShelf.Services
{
    public class BookShelf
    {
        private HashMap genreCatalog;
        private HashSet uniqueISBNs;

        public BookShelf()
        {
            this.genreCatalog=new HashMap();
            this.uniqueISBNs=new HashSet();
        }

        public void AddBook(Book book)
        {
            if(book==null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if(uniqueISBNs.Contains(book))
            {
                Console.WriteLine($"Error: Book with ISBN {book.GetISBN()} already exists!");
                return;
            }

            string genre=book.GetGenre();
            ILinkedList bookList=genreCatalog.Get(genre);

            if(bookList==null)
            {
                bookList=new LinkedList();
                genreCatalog.Put(genre,bookList);
            }

            bookList.Insert(book);
            uniqueISBNs.Add(book);
            Console.WriteLine($"Added: {book}");
        }

        public void RemoveBook(Book book)
        {
            if(book==null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            string genre=book.GetGenre();
            ILinkedList bookList=genreCatalog.Get(genre);

            if(bookList!=null)
            {
                bookList.Delete(book);
                uniqueISBNs.Remove(book);
                Console.WriteLine($"Removed: {book}");
            }
            else
            {
                Console.WriteLine($"Genre '{genre}' not found!");
            }
        }

        public void BorrowBook(string isbn)
        {
            Book book=FindBookByISBN(isbn);

            if(book==null)
            {
                Console.WriteLine($"Book with ISBN {isbn} not found!");
                return;
            }

            if(book.IsBorrowed())
            {
                Console.WriteLine($"Book '{book.GetTitle()}' is already borrowed!");
                return;
            }

            book.SetBorrowed(true);
            Console.WriteLine($"Borrowed: {book.GetTitle()}");
        }

        public void ReturnBook(string isbn)
        {
            Book book=FindBookByISBN(isbn);

            if(book==null)
            {
                Console.WriteLine($"Book with ISBN {isbn} not found!");
                return;
            }

            if(!book.IsBorrowed())
            {
                Console.WriteLine($"Book '{book.GetTitle()}' was not borrowed!");
                return;
            }

            book.SetBorrowed(false);
            Console.WriteLine($"Returned: {book.GetTitle()}");
        }

        private Book FindBookByISBN(string isbn)
        {
            for(int i=0;i<genreCatalog.GetSize();i++)
            {
                foreach(string genre in GetAllGenres())
                {
                    ILinkedList bookList=genreCatalog.Get(genre);
                    if(bookList==null)continue;

                    Node head=((LinkedList)bookList).GetHead();
                    Node current=head;

                    while(current!=null)
                    {
                        Book book=(Book)current.Data;
                        if(book.GetISBN()==isbn)
                        {
                            return book;
                        }
                        current=current.Next;
                    }
                }
            }
            return null;
        }

        public Book FindBook(string title)
        {
            foreach(string genre in GetAllGenres())
            {
                ILinkedList bookList=genreCatalog.Get(genre);
                if(bookList==null)continue;

                Node head=((LinkedList)bookList).GetHead();
                Node current=head;

                while(current!=null)
                {
                    Book book=(Book)current.Data;
                    if(book.GetTitle()==title)
                    {
                        return book;
                    }
                    current=current.Next;
                }
            }
            return null;
        }

        public void DisplayGenreBooks(string genre)
        {
            ILinkedList bookList=genreCatalog.Get(genre);

            if(bookList==null)
            {
                Console.WriteLine($"Genre '{genre}' not found!");
                return;
            }

            Console.WriteLine($"\nBooks in Genre: {genre}");
            Console.WriteLine(" ");

            Node head=((LinkedList)bookList).GetHead();
            Node current=head;

            if(current==null)
            {
                Console.WriteLine("No books in this genre.");
                return;
            }

            while(current!=null)
            {
                Console.WriteLine(current.Data);
                current=current.Next;
            }
        }

        public void DisplayAllGenres()
        {
            Console.WriteLine("\n****All Genres*****");
            foreach(string genre in GetAllGenres())
            {
                ILinkedList bookList=genreCatalog.Get(genre);
                Console.WriteLine($"{genre}: {bookList.GetSize()} books");
            }
        }

        public List<string> GetAllGenres()
{
    return genreCatalog.GetKeys();
}


        public int GetTotalBooks()
        {
            int total=0;
            foreach(string genre in GetAllGenres())
            {
                ILinkedList bookList=genreCatalog.Get(genre);
                if(bookList!=null)
                {
                    total+=bookList.GetSize();
                }
            }
            return total;
        }

        public int GetAvailableBooks()
        {
            int available=0;
            foreach(string genre in GetAllGenres())
            {
                ILinkedList bookList=genreCatalog.Get(genre);
                if(bookList==null)continue;

                Node head=((LinkedList)bookList).GetHead();
                Node current=head;

                while(current!=null)
                {
                    Book book=(Book)current.Data;
                    if(!book.IsBorrowed())
                    {
                        available++;
                    }
                    current=current.Next;
                }
            }
            return available;
        }
    }
}
