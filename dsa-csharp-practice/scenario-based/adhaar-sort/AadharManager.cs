public class AadharManager
{
    private string[] aadharNumbers=new string[100];
    private int count=0;
    private ISortable sorter;
    private ISearchable searcher;
    private IDisplayable displayer;
    
    public AadharManager()
    {
        sorter=new RadixSort(false);
        searcher=new BinarySearcher();
        displayer=(IDisplayable)sorter;
    }
    
    public void AddAadharNumber(string number)
    {
        if(count<100)
        {
            aadharNumbers[count]=number;
            count++;
            Console.WriteLine("\n Aadhar number added successfully!");
        }
        else
        {
            Console.WriteLine("\n Maximum capacity reached!");
        }
    }
    
    public void DisplayAllNumbers()
    {
        if(count==0)
        {
            Console.WriteLine("\n No Aadhar numbers in the database!");
            return;
        }
        
        Console.WriteLine("\n All Aadhar Numbers ");
        displayer.Display(aadharNumbers,count);
    }
    
    public void SortAscending()
    {
        if(count==0)
        {
            Console.WriteLine("\n No numbers to sort!");
            return;
        }
        
        sorter.Sort(aadharNumbers,count);
        Console.WriteLine("\n Numbers sorted in ascending order!");
    }
    
    public void SortStable()
    {
        if(count==0)
        {
            Console.WriteLine("\n No numbers to sort!");
            return;
        }
        
        sorter=new RadixSort(true);
        sorter.Sort(aadharNumbers,count);
        displayer=(IDisplayable)sorter;
        Console.WriteLine("\n Numbers sorted with stable ordering!");
    }
    
    public void SearchNumber(string number)
    {
        if(count==0)
        {
            Console.WriteLine("\n No numbers in database to search!");
            return;
        }
        
        int pos=searcher.Search(aadharNumbers,count,number);
        
        if(pos!=-1)
            Console.WriteLine("\n Number found at position: "+(pos+1));
        else
            Console.WriteLine("\n Number not found!");
    }
    
    public void DisplaySorted()
    {
        if(count==0)
        {
            Console.WriteLine("\n No numbers to display!");
            return;
        }
        
        Console.WriteLine("\n Sorted Aadhar Numbers ");
        displayer.Display(aadharNumbers,count);
    }
    
    public int GetCount()
    {
        return count;
    }
}