using System;
class ShoppingCart
    {
        static void Main(string[] args)
        {
            Item i1=new Item("bread",1200,2,2001);
            if (i1 is Item)
            {
                i1.Show();
            }
            Item.ChangeDiscount(15);
        }
    }
    public class Item
    {
        public static int discountValue=5;
        public int itemId;
        string itemName;
        int itemPrice;
        int itemQuantity;
        public Item(string itemName,int itemPrice,int itemQuantity,int itemId)
        {
            this.itemName=itemName;
            this.itemPrice=itemPrice;
            this.itemQuantity=itemQuantity;
            this.itemId=itemId;
        }
        public static void ChangeDiscount(int newValue)
        {
            discountValue=newValue;
            Console.WriteLine($"discount is {discountValue}");
        }
        public void Show()
        {
            Console.WriteLine($"item name is {itemName}");
            Console.WriteLine($"item price is {itemPrice}");
            Console.WriteLine($"item quantity is {itemQuantity}");
        }
    }
