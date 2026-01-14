using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class ConsoleInputToFile
	{
		static void Main(String[] args)
		{
			using(StreamWriter sw=new StreamWriter("result.txt"))
			{
				string entry;
				while((entry=Console.ReadLine())!="done")
				{
					sw.WriteLine(entry);
				}
			}
		}
	}
}
