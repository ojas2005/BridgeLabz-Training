using System;
using System.Collections.Generic;
public class SortStack
    {
        public static void Sort(Stack<int> s)
        {
            if(s.Count==0)
                return;
            int top=s.Pop();
            Sort(s);
            Insert(s,top);
        }

        private static void Insert(Stack<int> s,int x)
        {
            if(s.Count==0||s.Peek()<=x)
            {
                s.Push(x);
                return;
            }
            int top=s.Pop();
            Insert(s,x);
            s.Push(top);
        }

        public static List<int> GetSorted(Stack<int> s)
        {
            Stack<int> temp=new Stack<int>(s);
            Sort(temp);
            List<int> res=new List<int>();
            while(temp.Count>0)
                res.Add(temp.Pop());
            return res;
        }
    }
