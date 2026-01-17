namespace BookShelf.Interfaces
{
    public interface ILinkedList
    {
        void Insert(object data);
        void Delete(object data);
        bool Contains(object data);
        int GetSize();
        void Display();
    }
}
