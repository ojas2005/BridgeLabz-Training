abstract class WarehouseItem
{
    public string Name;
    public double Price;
    
    public WarehouseItem(string name,double price)
    {
        Name=name;
        Price=price;
    }
    
    public abstract void DisplayInfo();
}