namespace BookShelf.Interfaces
{
    public interface IHashMap
    {
        void Put(string key,ILinkedList value);
        ILinkedList Get(string key);
        void Remove(string key);
        bool ContainsKey(string key);
        int GetSize();
        void DisplayAllEntries();
    }
}
