public class Customer : ICustomer
{
    private string customerName;
    private List<CartItem> items;

    public Customer(string name)
    {
        customerName = name;
        items = new List<CartItem>();
    }

    public string GetCustomerName() => customerName;

    public List<CartItem> GetItems() => items;

    public void AddItem(CartItem item)
    {
        items.Add(item);
    }

    public decimal GetTotalPrice()
    {
        return items.Sum(item => item.GetSubtotal());
    }

    public override string ToString()
    {
        return $"Customer: {customerName} items: {items.Count} total: {GetTotalPrice()}rs";
    }
}