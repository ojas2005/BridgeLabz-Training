using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Marketplace<BookCategory> bookMarketplace=new Marketplace<BookCategory>();
        Product<BookCategory> book1=new Product<BookCategory>("The brief history of time",240,new BookCategory());
        Product<BookCategory> book2=new Product<BookCategory>("3 mistakes of my life",300,new BookCategory());
        bookMarketplace.AddProduct(book1);
        bookMarketplace.AddProduct(book2);
        bookMarketplace.DisplayAllProducts();
        
        bookMarketplace.ApplyDiscount(book1,20);
        bookMarketplace.DisplayAllProducts();
        
        Marketplace<ClothingCategory> clothingMarketplace=new Marketplace<ClothingCategory>();
        Product<ClothingCategory> shirt=new Product<ClothingCategory>("t-shirts",400,new ClothingCategory());
        Product<ClothingCategory> jeans=new Product<ClothingCategory>("blue jeans",750,new ClothingCategory());
        
        clothingMarketplace.AddProduct(shirt);
        clothingMarketplace.AddProduct(jeans);
        clothingMarketplace.DisplayAllProducts();
        
        clothingMarketplace.ApplyDiscount(jeans,15);
        clothingMarketplace.DisplayAllProducts();
    }
}
