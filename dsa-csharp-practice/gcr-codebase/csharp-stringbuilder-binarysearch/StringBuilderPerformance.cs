using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class StringBuilderPerformance
	{
		static void Main(String[] args)
		{
			int loop=100000;

			Stopwatch timer=Stopwatch.StartNew();
			string str="";
			for(int i=0;i<loop;i++)
				str+="a";
			timer.Stop();
			Console.WriteLine("string time: "+timer.ElapsedMilliseconds);

			timer.Restart();
			StringBuilder sb=new StringBuilder();
			for(int i=0;i<loop;i++)
				sb.Append("a");
			timer.Stop();
			Console.WriteLine("stringbuilder time: "+timer.ElapsedMilliseconds);
		}
	}
}
