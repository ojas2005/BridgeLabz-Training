using System;
public class Program{
    static void Main()
    {
        Console.WriteLine("enter number of items");
        int n = int.Parse(Console.ReadLine());
        Product[] products=new Product[n];
        for(int i = 0;i<n;i++)
        {
            Console.WriteLine($"enter name of product{i+1}");
            string name = Console.ReadLine();
            Console.WriteLine($"enter price of product{i+1}");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine($"enter discount percentage of product{i+1}");
            double discountPercent = int.Parse(Console.ReadLine());
            double finalPrice = price-((discountPercent*price)/100);
            products[i] = new Product(name,finalPrice,discountPercent);
        }
        FlashDealz fd = new FlashDealz();
        Console.WriteLine("before sorting:");
        fd.DisplayProducts(products);
        Console.WriteLine(" ");
        fd.quickSort(products,0,products.Length-1);
        Console.WriteLine("after quick sort");
        fd.DisplayProducts(products);

    }
}
