using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class ReadFileLineByLine
	{
		static void Main(String[] args)
		{
			using(StreamReader fr=new StreamReader("data.txt"))
			{
				string record;
				while((record=fr.ReadLine())!=null)
				{
					Console.WriteLine(record);
				}
			}
		}
	}
}
