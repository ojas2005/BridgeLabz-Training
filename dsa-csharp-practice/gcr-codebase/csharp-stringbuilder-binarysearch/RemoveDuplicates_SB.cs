using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class RemoveDuplicates_SB
	{
		static void Main(String[] args)
		{
			string text="programming";
			HashSet<char> unique=new HashSet<char>();
			StringBuilder result=new StringBuilder();

			foreach(char ch in text)
			{
				if(unique.Add(ch))
				{
					result.Append(ch);
				}
			}

			Console.WriteLine(result.ToString());
		}
	}
}
