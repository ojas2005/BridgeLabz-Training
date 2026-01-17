namespace BookShelf.Interfaces
{
    public interface IHashSet
    {
        void Add(object data);
        void Remove(object data);
        bool Contains(object data);
        int GetSize();
    }
}
