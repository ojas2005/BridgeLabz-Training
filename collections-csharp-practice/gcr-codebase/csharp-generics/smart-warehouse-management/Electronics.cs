using System;
class Electronics:WarehouseItem
{
    public string Brand;
    
    public Electronics(string name,double price,string brand):base(name,price)
    {
        Brand=brand;
    }
    
    public override void DisplayInfo()
    {
        Console.WriteLine($"electronics:- {Name},price: {Price}rs, brand:- {Brand}");
    }
}