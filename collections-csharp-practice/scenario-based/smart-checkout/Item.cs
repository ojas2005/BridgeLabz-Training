public class Item : IItem
{
    private string name;
    private decimal price;
    private int stock;

    public Item(string name, decimal price, int stock)
    {
        this.name = name;
        this.price = price;
        this.stock = stock;
    }

    public string GetName() => name;
    
    public decimal GetPrice() => price;
    
    public int GetStock() => stock;
    
    public void UpdateStock(int quantity)
    {
        stock -= quantity;
    }

    public bool IsAvailable(int quantity)
    {
        return stock >= quantity;
    }

    public override string ToString()
    {
        return $"item name:- {name} - price:- {price}rs - stock:- {stock}";
    }
}