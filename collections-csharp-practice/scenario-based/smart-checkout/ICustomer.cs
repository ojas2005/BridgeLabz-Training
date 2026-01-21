public interface ICustomer
{
    string GetCustomerName();
    List<CartItem> GetItems();
    void AddItem(CartItem item);
    decimal GetTotalPrice();
}