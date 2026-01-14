using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StringConcatenationComparison
{
    static void Main()
    {
        int[] opCounts={2000,20000,200000};

        foreach(int cnt in opCounts)
        {
            Console.WriteLine("\nops count: "+cnt);

            //basic string concat-very slow
            if(cnt<=20000)
            {
                Stopwatch t1=Stopwatch.StartNew();
                BuildWithConcat(cnt);
                t1.Stop();
                Console.WriteLine("concat method: "+t1.ElapsedTicks+" ticks");
            }
            else
            {
                Console.WriteLine("concat method: too slow (skip)");
            }

            //using stringbuilder-much faster
            Stopwatch t2=Stopwatch.StartNew();
            BuildWithBuilder(cnt);
            t2.Stop();
            Console.WriteLine("builder method: "+t2.ElapsedTicks+" ticks");
        }
    }

    //inefficient string accumulation
    static void BuildWithConcat(int n)
    {
        string txt="";
        string sampleLine=ReadSampleText();
        for(int i=0; i<n; i++)
        {
            txt+=sampleLine.Substring(0, 5);
        }
    }

    //efficient buffer approach
    static void BuildWithBuilder(int n)
    {
        StringBuilder sb=new StringBuilder();
        string sampleLine=ReadSampleText();
        for(int i=0; i<n; i++)
        {
            sb.Append(sampleLine.Substring(0, 5));
        }
    }

    static string ReadSampleText()
    {
        try
        {
            return File.ReadAllText("sample-data.txt").Trim();
        }
        catch
        {
            return "sample";
        }
    }
}
