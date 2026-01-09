using System;
using System.Collections.Generic;
using System.Linq;
public class SlidingWindowMaximum
    {
        public static int[] FindMaxInWindows(int[] arr,int k)
        {
            if(arr.Length==0||k<=0)
                return new int[0];
            
            int n=arr.Length;
            List<int> res=new List<int>();
            Deque<int> dq=new Deque<int>();

            for(int i=0;i<n;i++)
            {
                if(dq.Count>0&&dq.PeekFront()<i-k+1)
                    dq.PopFront();

                while(dq.Count>0&&arr[dq.PeekBack()]<=arr[i])
                    dq.PopBack();

                dq.PushBack(i);

                if(i>=k-1)
                    res.Add(arr[dq.PeekFront()]);
            }
            return res.ToArray();
        }
    }

    public class Deque<T>
    {
        private LinkedList<T> data;

        public Deque()
        {
            data=new LinkedList<T>();
        }

        public void PushFront(T x)
        {
            data.AddFirst(x);
        }

        public void PushBack(T x)
        {
            data.AddLast(x);
        }

        public T PopFront()
        {
            if(data.Count==0)
                throw new InvalidOperationException("Deque is empty");
            T val=data.First.Value;
            data.RemoveFirst();
            return val;
        }

        public T PopBack()
        {
            if(data.Count==0)
                throw new InvalidOperationException("Deque is empty");
            T val=data.Last.Value;
            data.RemoveLast();
            return val;
        }

        public T PeekFront()
        {
            return data.First.Value;
        }

        public T PeekBack()
        {
            return data.Last.Value;
        }

        public int Count
        {
            get{return data.Count;}
        }
    }
