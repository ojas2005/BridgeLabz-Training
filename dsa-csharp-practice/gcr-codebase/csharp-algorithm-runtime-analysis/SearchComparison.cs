using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SearchComparison
{
    static void Main()
    {
        int[] testSizes={5000,50000,500000};
        int lookupVal=-1;

        foreach(int sz in testSizes)
        {
            int[] dataset=GenerateNumList(sz);

            Console.WriteLine("\ndataset sz: "+sz);

            //linear approach-checks each element
            Stopwatch timer=Stopwatch.StartNew();
            LinearLookup(dataset, lookupVal);
            timer.Stop();
            Console.WriteLine("linear lookup: "+timer.ElapsedTicks+" ticks");

            //binary approach-needs sorted data
            Array.Sort(dataset);

            timer.Restart();
            BinaryLookup(dataset, lookupVal);
            timer.Stop();
            Console.WriteLine("binary lookup: "+timer.ElapsedTicks+" ticks");
        }
    }

    static Random rnd=new Random();

    static int[] GenerateNumList(int count)
    {
        int[] nums=new int[count];
        for(int i=0; i<count; i++)
            nums[i]=rnd.Next(1, count);
        return nums;
    }

    //linear scan-slowest for large data
    static int LinearLookup(int[] arr, int val)
    {
        for(int i=0; i<arr.Length; i++)
        {
            if(arr[i]==val)
                return i;
        }
        return -1;
    }

    //binary search-fast but needs sorted array
    static int BinaryLookup(int[] arr, int val)
    {
        int lo=0, hi=arr.Length-1;

        while(lo<=hi)
        {
            int mid=(lo+hi)/2;

            if(arr[mid]==val)
                return mid;
            else if(arr[mid]<val)
                lo=mid+1;
            else
                hi=mid-1;
        }
        return -1;
    }
}
