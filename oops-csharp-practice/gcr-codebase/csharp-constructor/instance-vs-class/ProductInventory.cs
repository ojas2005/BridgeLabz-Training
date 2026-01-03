using System;
class ProductInventory
    {
        string productName;
        double price;
        static int totalProduct;
        //creating constructor
        public ProductInventory(string productName, double price)
        {
            this.productName = productName;
            this.price = price;
            totalProduct++;
        }
        //display method to display details
        public void DisplayProductDetails()
        {
            Console.WriteLine($"Product: {productName}, price: {price}");
        }
        //To display number of total products available
        static public void DisplayTotalProducts()
        {
            Console.WriteLine($"total number of product are {totalProduct}");
        }


    }
