using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class FileReadingComparison
{
    static void Main()
    {
        string fpath="sample-data.txt";

        if(!File.Exists(fpath))
        {
            Console.WriteLine("file not found");
            return;
        }

        Console.WriteLine("file read perf test");

        //streamreader-character approach
        Stopwatch t1=Stopwatch.StartNew();
        ReadWithStream(fpath);
        t1.Stop();
        Console.WriteLine("streamreader: "+t1.ElapsedTicks+" ticks");

        //filestream-byte chunks
        Stopwatch t2=Stopwatch.StartNew();
        ReadWithBytes(fpath);
        t2.Stop();
        Console.WriteLine("filestream: "+t2.ElapsedTicks+" ticks");
    }

    //text reading per char
    static void ReadWithStream(string path)
    {
        using(StreamReader sr=new StreamReader(path))
        {
            while(sr.Read()!=-1)
            {
                //reading char by char
            }
        }
    }

    //binary chunks reading
    static void ReadWithBytes(string path)
    {
        using(FileStream fs=new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buf=new byte[4096];
            while(fs.Read(buf, 0, buf.Length)>0)
            {
                //chunk reading
            }
        }
    }
}
