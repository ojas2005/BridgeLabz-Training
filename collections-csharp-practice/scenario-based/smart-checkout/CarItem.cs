public class CartItem
{
    public IItem Item { get; set; }
    public int Quantity { get; set; }

    public CartItem(IItem item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public decimal GetSubtotal()
    {
        return Item.GetPrice() * Quantity;
    }
}