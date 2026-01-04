using System;
class EcommercePlatform
    {
        static void Main(string[] args)
        {
            Buyer b1 = new Buyer("Rahul");
            Purchase p1 = b1.CreateOrder();

            p1.AddItem(new Item("Mobile"));
            p1.Show();
        }
    }
    class Buyer
    {
        public string buyerName;

        public Buyer(string buyerName)
        {
            this.buyerName = buyerName;
        }

        public Purchase CreateOrder()
        {
            return new Purchase();
        }
    }

    class Purchase
    {
        Item[] items = new Item[5];
        int count = 0;

        public void AddItem(Item item)
        {
            items[count++] = item;
        }

        public void Show()
        {
            Console.WriteLine($"items ordered are");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{items[i].itemName}");
            }
        }
    }

    class Item
    {
        public string itemName;

        public Item(string itemName)
        {
            this.itemName = itemName;
        }
    }
