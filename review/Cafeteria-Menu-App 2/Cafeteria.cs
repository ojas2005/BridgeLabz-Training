class Cafeteria
{
    public MenuItem[] items=new MenuItem[10];
    public Cafeteria()
    {
        Console.WriteLine("enter the 10 menu items");
        for (int i=0; i < items.Length; i++)
        {
            Console.WriteLine($"enter {i+1} item name ");
            string name=Console.ReadLine();
            Console.WriteLine($"enter {i+1}item price ");
            double price=Convert.ToDouble(Console.ReadLine());
            items[i]=new MenuItem(name,price);
            Console.Clear();
            Console.WriteLine();
        }
    }
    public void DisplayMenu()
    {
        Console.WriteLine("");
        for (int i=0;i<items.Length;i++)
        {
            Console.WriteLine($"item number {i+1}  name-{items[i].name}   price-{items[i].price}rs");
        }
    }
    public double TotalBill(int index, int quantity)
    {
        return items[index].price*quantity;
    }
    public void UpdatePrice(int index,double newPrice)
    {
        items[index].price=newPrice;
        Console.WriteLine("new price will now be apllicable");
    }
}

