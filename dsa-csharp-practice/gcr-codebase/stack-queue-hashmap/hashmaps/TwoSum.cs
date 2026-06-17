using System;
using System.Collections.Generic;
    public class TwoSum
    {
        public static (int,int) FindTwoSum(int[] arr,int target)
        {
            Dictionary<int,int> map=new Dictionary<int,int>();

            for(int i=0;i<arr.Length;i++)
            {
                int comp=target-arr[i];
                if(map.ContainsKey(comp))
                {
                    return (map[comp],i);
                }
                if(!map.ContainsKey(arr[i]))
                    map[arr[i]]=i;
            }

            return (-1,-1);
        }

        public static List<(int,int)> FindAllUniquePairs(int[] arr,int target)
        {
            List<(int,int)> res=new List<(int,int)>();
            HashSet<int> seen=new HashSet<int>();
            HashSet<string> added=new HashSet<string>();

            foreach(int x in arr)
            {
                int comp=target-x;
                if(seen.Contains(comp))
                {
                    string key=Math.Min(comp,x)+","+Math.Max(comp,x);
                    if(!added.Contains(key))
                    {
                        res.Add((comp,x));
                        added.Add(key);
                    }
                }
                seen.Add(x);
            }

            return res;
        }
    }
