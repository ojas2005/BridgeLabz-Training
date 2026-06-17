using BookShelf.Interfaces;

namespace BookShelf.Models
{
    public class Book:IBook
    {
        private string title;
        private string author;
        private string genre;
        private string isbn;
        private bool isBorrowed;

        public Book(string title,string author,string genre,string isbn)
        {
            this.title=title;
            this.author=author;
            this.genre=genre;
            this.isbn=isbn;
            this.isBorrowed=false;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public string GetGenre()
        {
            return genre;
        }

        public string GetISBN()
        {
            return isbn;
        }

        public bool IsBorrowed()
        {
            return isBorrowed;
        }

        public void SetBorrowed(bool borrowed)
        {
            isBorrowed=borrowed;
        }

        public override string ToString()
        {
            string borrowStatus=isBorrowed?"Borrowed":"Available";
            return $"'{title}' by {author} (ISBN: {isbn}) - {borrowStatus}";
        }

        public override bool Equals(object obj)
        {
            if(obj==null||!(obj is Book))
            {
                return false;
            }

            Book other=(Book)obj;
            return isbn==other.isbn;
        }

        public override int GetHashCode()
        {
            return isbn.GetHashCode();
        }
    }
}
