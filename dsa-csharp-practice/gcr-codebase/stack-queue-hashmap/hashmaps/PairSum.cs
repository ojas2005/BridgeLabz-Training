using System;
using System.Collections.Generic;
public class PairSum
    {
        public static bool FindPair(int[] arr,int target)
        {
            HashSet<int> seen=new HashSet<int>();

            foreach(int x in arr)
            {
                int comp=target-x;
                if(seen.Contains(comp))
                    return true;
                seen.Add(x);
            }
            return false;
        }

        public static List<(int,int)> FindAllPairs(int[] arr,int target)
        {
            List<(int,int)> res=new List<(int,int)>();
            HashSet<int> used=new HashSet<int>();
            HashSet<int> seen=new HashSet<int>();

            foreach(int x in arr)
            {
                int comp=target-x;
                if(seen.Contains(comp)&&!used.Contains(x))
                {
                    res.Add((comp,x));
                    used.Add(comp);
                    used.Add(x);
                }
                seen.Add(x);
            }
            return res;
        }
    }
