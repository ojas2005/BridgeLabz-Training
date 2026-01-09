using System;
using System.Collections.Generic;
    public class ZeroSumSubarray
    {
        public static List<(int,int)> FindZeroSumSubarrays(int[] arr)
        {
            List<(int,int)> res=new List<(int,int)>();
            Dictionary<int,List<int>> sumIdx=new Dictionary<int,List<int>>();
            int csum=0;

            sumIdx[0]=new List<int>{-1};

            for(int i=0;i<arr.Length;i++)
            {
                csum+=arr[i];

                if(sumIdx.ContainsKey(csum))
                {
                    foreach(int j in sumIdx[csum])
                    {
                        res.Add((j+1,i));
                    }
                }

                if(!sumIdx.ContainsKey(csum))
                    sumIdx[csum]=new List<int>();
                sumIdx[csum].Add(i);
            }

            return res;
        }
    }
