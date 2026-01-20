using System;
using System.Diagnostics;
class NumericPasswordBreaker
    {
        static bool solved=false;

        static void TryBreak(int[] buffer,int pos,int secret,int size)
        {
            if(solved)
                return;

            if(pos==size)
            {
                int value=0;
                for(int i=0;i<size;i++)
                    value=value*10+buffer[i];

                if(value==secret)
                {
                    Console.WriteLine("password cracked: "+value);
                    solved=true;
                }
                return;
            }

            for(int d=0;d<=9;d++)
            {
                buffer[pos]=d;
                TryBreak(buffer,pos+1,secret,size);
            }
        }

        static void Main()
        {
            Console.Write("enter password: ");
            int secret=Convert.ToInt32(Console.ReadLine());
            int size=Math.Abs(secret).ToString().Length;

            int[] buffer=new int[size];
            Stopwatch timer=new Stopwatch();

            timer.Start();
            TryBreak(buffer,0,secret,size);
            timer.Stop();

            Console.WriteLine("time taken: "+timer.ElapsedTicks+"ticks");

            if(!solved)
                Console.WriteLine("password not cracked.");
        }
    }

