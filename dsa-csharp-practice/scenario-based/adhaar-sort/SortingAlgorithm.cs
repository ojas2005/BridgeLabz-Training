abstract class SortingAlgorithm:ISortable,IDisplayable
{
    protected int size=0;
    
    public abstract void Sort(string[] arr,int n);
    
    public virtual void Display(string[] arr,int n)
    {
        for(int i=0;i<n;i++)
            Console.WriteLine((i+1)+". "+arr[i]);
    }
}