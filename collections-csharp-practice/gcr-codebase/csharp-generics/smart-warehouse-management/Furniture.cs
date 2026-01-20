using System;
class Furniture:WarehouseItem
{
    public string Material;
    public Furniture(string name,double price,string material):base(name,price)
    {
        Material=material;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"furniture:- {Name},price:- {Price}rs, material:- {Material}");
    }
}