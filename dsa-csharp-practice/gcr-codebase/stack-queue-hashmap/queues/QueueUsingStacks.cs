using System;
using System.Collections.Generic;
public class QueueUsingStacks<T>
    {
        private Stack<T> stackIn;
        private Stack<T> stackOut;

        public QueueUsingStacks()
        {
            stackIn=new Stack<T>();
            stackOut=new Stack<T>();
        }

        public void Enqueue(T x)
        {
            stackIn.Push(x);
        }

        public T Dequeue()
        {
            if(stackOut.Count==0)
            {
                if(stackIn.Count==0)
                    throw new InvalidOperationException("Queue is empty");
                while(stackIn.Count>0)
                {
                    stackOut.Push(stackIn.Pop());
                }
            }
            return stackOut.Pop();
        }

        public bool IsEmpty()
        {
            return stackIn.Count==0&&stackOut.Count==0;
        }

        public int Size()
        {
            return stackIn.Count+stackOut.Count;
        }
    }

