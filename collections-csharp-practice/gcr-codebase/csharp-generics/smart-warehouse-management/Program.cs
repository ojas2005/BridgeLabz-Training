using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Storage<Electronics> electronicsStorage=new Storage<Electronics>();
        electronicsStorage.AddItem(new Electronics("MacBook m4",99999,"Apple"));
        electronicsStorage.AddItem(new Electronics("iPhone 15 pro",127000,"Apple"));
        electronicsStorage.DisplayAllItems();
        
        Storage<Groceries> groceriesStorage=new Storage<Groceries>();
        groceriesStorage.AddItem(new Groceries("Milk",45,"22-01-2026"));
        groceriesStorage.AddItem(new Groceries("Bread",50,"24-01-2026"));
        groceriesStorage.DisplayAllItems();
        
        Storage<Furniture> furnitureStorage=new Storage<Furniture>();
        furnitureStorage.AddItem(new Furniture("Chair",1500,"Wood"));
        furnitureStorage.AddItem(new Furniture("Table",3000,"Glass"));
        furnitureStorage.DisplayAllItems();
    }
}
