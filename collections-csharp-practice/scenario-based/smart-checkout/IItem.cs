public interface IItem
{
    string GetName();
    decimal GetPrice();
    int GetStock();
    void UpdateStock(int quantity);
    bool IsAvailable(int quantity);
}