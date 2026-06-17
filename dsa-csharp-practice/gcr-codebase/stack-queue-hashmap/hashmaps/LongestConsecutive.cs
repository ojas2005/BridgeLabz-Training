using System;
using System.Collections.Generic;
public class LongestConsecutive{
    public static int FindLength(int[] arr)
        {
            if(arr.Length==0)
                return 0;

            HashSet<int> nums=new HashSet<int>(arr);
            int maxLen=0;
            foreach(int x in nums)
            {
                if(nums.Contains(x-1)==false)
                {
                    int curr=x;
                    int len=1;
                    while(nums.Contains(curr+1))
                    {
                        curr++;
                        len++;
                    }
                    maxLen=Math.Max(maxLen,len);
                }
            }

            return maxLen;
        }
    }

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter number of elements");
        int n=int.Parse(Console.ReadLine());
        int[] arr=new int[n];
        Console.WriteLine("enter elements");
        for(int i=0;i<n;i++)
            arr[i]=int.Parse(Console.ReadLine());
        int result=LongestConsecutive.FindLength(arr);
        Console.WriteLine($"longest consecutive length is {result}");
    }
}

