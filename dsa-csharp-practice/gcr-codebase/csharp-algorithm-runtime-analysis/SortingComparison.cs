using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SortingComparison
{
    static void Main()
    {
        int[] sz={3000,30000,300000};

        foreach(int size in sz)
        {
            Console.WriteLine("\narray sz: "+size);

            int[] orig=GenList(size);

            //bubble sort-simple but slow
            if(size<=30000)
            {
                int[] bd=(int[])orig.Clone();
                Stopwatch t1=Stopwatch.StartNew();
                BubbleSort(bd);
                t1.Stop();
                Console.WriteLine("bubble: "+t1.ElapsedMilliseconds+" ms");
            }
            else
            {
                Console.WriteLine("bubble: skip");
            }

            //merge sort-divide and conquer
            int[] md=(int[])orig.Clone();
            Stopwatch t2=Stopwatch.StartNew();
            MergeSort(md, 0, md.Length-1);
            t2.Stop();
            Console.WriteLine("merge: "+t2.ElapsedMilliseconds+" ms");

            //quick sort-partitioning
            int[] qd=(int[])orig.Clone();
            Stopwatch t3=Stopwatch.StartNew();
            QuickSort(qd, 0, qd.Length-1);
            t3.Stop();
            Console.WriteLine("quick: "+t3.ElapsedMilliseconds+" ms");
        }
    }

    static Random rnd=new Random();

    static int[] GenList(int n)
    {
        int[] lst=new int[n];
        for(int i=0; i<n; i++)
            lst[i]=rnd.Next(1, n);
        return lst;
    }

    //bubble method-comparing adjacent pairs
    static void BubbleSort(int[] arr)
    {
        for(int i=0; i<arr.Length-1; i++)
        {
            for(int j=0; j<arr.Length-i-1; j++)
            {
                if(arr[j]>arr[j+1])
                {
                    int tmp=arr[j];
                    arr[j]=arr[j+1];
                    arr[j+1]=tmp;
                }
            }
        }
    }

    //merge method-recursive divide
    static void MergeSort(int[] arr, int l, int r)
    {
        if(l>=r)
            return;

        int m=(l+r)/2;

        MergeSort(arr, l, m);
        MergeSort(arr, m+1, r);
        MergeParts(arr, l, m, r);
    }

    //combine sorted parts
    static void MergeParts(int[] arr, int l, int m, int r)
    {
        int[] tmp=new int[r-l+1];
        int p=l, q=m+1, k=0;

        while(p<=m&&q<=r)
            tmp[k++]=arr[p]<=arr[q]?arr[p++]:arr[q++];

        while(p<=m)
            tmp[k++]=arr[p++];

        while(q<=r)
            tmp[k++]=arr[q++];

        for(p=l, k=0; p<=r; p++, k++)
            arr[p]=tmp[k];
    }

    //quick method-pivot partitioning
    static void QuickSort(int[] arr, int lo, int hi)
    {
        if(lo>=hi)
            return;

        int pv=Partition(arr, lo, hi);
        QuickSort(arr, lo, pv-1);
        QuickSort(arr, pv+1, hi);
    }

    //split around pivot
    static int Partition(int[] arr, int lo, int hi)
    {
        int pv=arr[hi];
        int p=lo-1;

        for(int j=lo; j<hi; j++)
        {
            if(arr[j]<pv)
            {
                p++;
                int tmp=arr[p];
                arr[p]=arr[j];
                arr[j]=tmp;
            }
        }

        int swp=arr[p+1];
        arr[p+1]=arr[hi];
        arr[hi]=swp;

        return p+1;
    }
}
