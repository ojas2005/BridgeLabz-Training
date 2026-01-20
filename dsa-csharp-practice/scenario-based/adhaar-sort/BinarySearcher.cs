class BinarySearcher:ISearchable
{
    public int Search(string[] arr,int n,string target)
    {
        int low=0;
        int high=n-1;
        
        while(low<=high)
        {
            int mid=(low+high)/2;
            int cmp=String.Compare(arr[mid],target);
            
            if(cmp==0)
                return mid;
            else if(cmp<0)
                low=mid+1;
            else
                high=mid-1;
        }
        
        return -1;
    }
}