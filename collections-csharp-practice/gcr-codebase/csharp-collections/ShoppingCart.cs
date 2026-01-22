using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections
{
    internal class ShoppingCart
    {
        private Dictionary<string, double> _inventory;
        private List<string> _purchaseSequence;

        public ShoppingCart()
        {
            _inventory = new Dictionary<string, double>();
            _purchaseSequence = new List<string>();
        }

        private void AddProduct(string productName, double amount)
        {
            _inventory[productName] = amount;
            _purchaseSequence.Add(productName);
        }

        private void ShowItemsByPrice()
        {
            SortedDictionary<double, string> priceIndex = new SortedDictionary<double, string>(_inventory);
            Console.WriteLine("Items Ordered by Price:");
            foreach (var item in priceIndex)
                Console.WriteLine($"{item.Value} - Rupees {item.Key}");
        }

        public static void Main(string[] args)
        {
            ShoppingCart store = new ShoppingCart();
            store.AddProduct("Laptop", 75000);
            store.AddProduct("Mouse", 500);
            store.AddProduct("Keyboard", 1500);
            store.AddProduct("Monitor", 15000);
            store.ShowItemsByPrice();
        }
    }
}
