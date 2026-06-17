class RadixSort:SortingAlgorithm
{
    private bool isStable=false;
    
    public RadixSort(bool stable=false)
    {
        isStable=stable;
    }
    
    public override void Sort(string[] arr,int n)
    {
        int maxLen=12;
        
        for(int digit=maxLen-1;digit>=0;digit--)
        {
            if(isStable)
                CountingSortByDigitStable(arr,n,digit);
            else
                CountingSortByDigit(arr,n,digit);
        }
    }
    
    private void CountingSortByDigit(string[] arr,int n,int digitPos)
    {
        string[] output=new string[n];
        int[] count=new int[10];
        
        for(int i=0;i<10;i++)
            count[i]=0;
        
        for(int i=0;i<n;i++)
            count[int.Parse(arr[i][digitPos].ToString())]++;
        
        for(int i=1;i<10;i++)
            count[i]+=count[i-1];
        
        for(int i=n-1;i>=0;i--)
        {
            int digit=int.Parse(arr[i][digitPos].ToString());
            output[count[digit]-1]=arr[i];
            count[digit]--;
        }
        
        for(int i=0;i<n;i++)
            arr[i]=output[i];
    }
    
    private void CountingSortByDigitStable(string[] arr,int n,int digitPos)
    {
        string[] temp=new string[n];
        int[] bucket=new int[10];
        
        for(int i=0;i<10;i++)
            bucket[i]=0;
        
        for(int i=0;i<n;i++)
        {
            int digit=int.Parse(arr[i][digitPos].ToString());
            bucket[digit]++;
        }
        
        for(int i=1;i<10;i++)
            bucket[i]+=bucket[i-1];
        
        for(int i=n-1;i>=0;i--)
        {
            int digit=int.Parse(arr[i][digitPos].ToString());
            bucket[digit]--;
            temp[bucket[digit]]=arr[i];
        }
        
        for(int i=0;i<n;i++)
            arr[i]=temp[i];
    }
}