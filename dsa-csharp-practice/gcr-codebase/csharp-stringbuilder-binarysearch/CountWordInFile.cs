using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class CountWordInFile
	{
		static void Main(String[] args)
		{
			string keyword="test";
			int total=0;

			using(StreamReader sr=new StreamReader("input.txt"))
			{
				string text;
				while((text=sr.ReadLine())!=null)
				{
					total+=text.Split(keyword).Length-1;
				}
			}

			Console.WriteLine(total);
		}
	}
}
