class Marketplace<T> where T:ProductCategory
{
    private List<Product<T>> products=new List<Product<T>>();
    
    public void AddProduct(Product<T> product)
    {
        products.Add(product);
        Console.WriteLine($"product added:- {product.Name}");
    }
    public void ApplyDiscount(Product<T> product,double percentage)
    {
        double discountAmount=product.Price*percentage/100;
        product.Price-=discountAmount;
        Console.WriteLine($"discount applied to {product.Name}: {discountAmount:F2}rs (new price: {product.Price:F2}rs)");
    }
    public void DisplayAllProducts()
    {
        Console.WriteLine("\nproduct catalog");
        foreach(Product<T> product in products)
        {
            product.DisplayProduct();
        }
        Console.WriteLine();
    }
}