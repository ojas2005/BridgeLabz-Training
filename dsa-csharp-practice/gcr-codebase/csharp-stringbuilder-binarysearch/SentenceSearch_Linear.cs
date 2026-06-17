using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class SentenceSearch_Linear
	{
		static void Main(String[] args)
		{
			string[] lines={"csharp eafg","java bsrgesrb","python rgegsfbv"};
			string find="python";

			foreach(string line in lines)
			{
				if(line.Contains(find))
				{
					Console.WriteLine(line);
					break;
				}
			}
		}
	}
}
