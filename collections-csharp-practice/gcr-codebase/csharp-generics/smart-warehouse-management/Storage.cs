using System;
class Storage<T> where T:WarehouseItem
{
    private List<T> items=new List<T>();
    public void AddItem(T item)
    {
        items.Add(item);
        Console.WriteLine($"item added:- {item.Name}");
    }
    public void RemoveItem(T item)
    {
        items.Remove(item);
        Console.WriteLine($"item removed:- {item.Name}");
    }
    public void DisplayAllItems()
    {
        Console.WriteLine("\nWarehouse Inventory");
        foreach(T item in items)
        {
            item.DisplayInfo();
        }
        Console.WriteLine($"total items:- {items.Count}\n");
    }
    public int GetItemCount()
    {
        return items.Count;
    }
}