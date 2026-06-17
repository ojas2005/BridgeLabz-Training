public class FlashDealz : IFlashDealz
{
  public void quickSort(Product[] products,int low,int high)
  {
    if(low<high)
    {
      int pi=partition(products,low,high);
      quickSort(products,low,pi-1);
      quickSort(products,pi+1,high);
    }
  }

  private static int partition(Product[] products,int low,int high)
  {
    double pivot=products[high].discountPercent;
    int i=low-1;

    for(int j=low;j<high;j++)
    {
      if(products[j].discountPercent>pivot)
      {
        i++;
        Product temp=products[i];
        products[i]=products[j];
        products[j]=temp;
      }
    }
    Product swap=products[i+1];
    products[i+1]=products[high];
    products[high]=swap;
    return i+1;
  }
  public void DisplayProducts(Product[] products)
  {
    Console.WriteLine("Displaying Products");
    for(int i=0;i<products.Length;i++)
    {
      Console.WriteLine($"Product number {i+1}:- {products[i].name}-{products[i].discountPercent}% off - Final Price ${products[i].price}");
    }
  }

}