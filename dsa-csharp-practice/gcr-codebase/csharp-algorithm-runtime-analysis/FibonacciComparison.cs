using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class FibonacciComparison
{
    static void Main()
    {
        long[] nums={12,35,48};

        foreach(long n in nums)
        {
            Console.WriteLine("\nfib value n: "+n);

            //recursion approach-exponential time
            if(n<=35)
            {
                Stopwatch t1=Stopwatch.StartNew();
                long res1=FibRecursive(n);
                t1.Stop();
                Console.WriteLine("recursive result: "+res1);
                Console.WriteLine("recursive time: "+t1.ElapsedTicks+" ticks");
            }
            else
            {
                Console.WriteLine("recursive time: way too slow");
            }

            //iterative approach-linear time
            Stopwatch t2=Stopwatch.StartNew();
            long res2=FibIterative(n);
            t2.Stop();
            Console.WriteLine("iterative result: "+res2);
            Console.WriteLine("iterative time: "+t2.ElapsedTicks+" ticks");
        }
    }

    //exponential complexity-not practical
    static long FibRecursive(long n)
    {
        if(n<=1)
            return n;

        return FibRecursive(n-1)+FibRecursive(n-2);
    }

    //linear complexity-much better
    static long FibIterative(long n)
    {
        if(n<=1)
            return n;

        long x=0, y=1, z=0;

        for(long i=2; i<=n; i++)
        {
            z=x+y;
            x=y;
            y=z;
        }
        return y;
    }
}
