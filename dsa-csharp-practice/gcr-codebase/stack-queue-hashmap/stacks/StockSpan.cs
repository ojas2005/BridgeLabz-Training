using System;
using System.Collections.Generic;
public class StockSpan
    {
        public static int[] CalculateSpan(int[] p)
        {
            int n=p.Length;
            int[] span=new int[n];
            Stack<int> idx=new Stack<int>();

            for(int i=0;i<n;i++)
            {
                while(idx.Count>0&& p[idx.Peek()]<=p[i])
                    idx.Pop();
                span[i]=(idx.Count==0)?i+1:i-idx.Peek();
                idx.Push(i);
            }
            return span;
        }
    }
