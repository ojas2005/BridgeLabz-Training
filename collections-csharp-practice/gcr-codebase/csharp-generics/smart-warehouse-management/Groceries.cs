using System;
class Groceries:WarehouseItem
{
    public string ExpiryDate;
    
    public Groceries(string name,double price,string expiryDate):base(name,price)
    {
        ExpiryDate=expiryDate;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"groceries: {Name}, price:{Price}rs, expiry date: {ExpiryDate}");
    }
}