using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class ConcatenateArray_SB
	{
		static void Main(String[] args)
		{
			string[] items={"code"," ","in"," ","csharp"};
			StringBuilder builder=new StringBuilder();

			foreach(string item in items)
			{
				builder.Append(item);
			}

			Console.WriteLine(builder.ToString());
		}
	}
}
