class Product<T> where T:ProductCategory
{
    public string Name;
    public double Price;
    public T Category;
    
    public Product(string name,double price,T category)
    {
        Name=name;
        Price=price;
        Category=category;
    }
    
    public void DisplayProduct()
    {
        Console.WriteLine($"product:- {Name}, price:- {Price}rs, category:- {Category.CategoryName}");
    }
}