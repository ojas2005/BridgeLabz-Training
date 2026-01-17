namespace BookShelf.Interfaces
{
    public interface IBook
    {
        string GetTitle();
        string GetAuthor();
        string GetGenre();
        string GetISBN();
        bool IsBorrowed();
        void SetBorrowed(bool borrowed);
    }
}
