using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class ReverseString_SB
	{
		static void Main(String[] args)
		{
			string msg="hello";
			StringBuilder rev=new StringBuilder(msg.Length);

			for(int i=msg.Length-1;i>=0;i--)
			{
				rev.Append(msg[i]);
			}

			Console.WriteLine(rev.ToString());
		}
	}
}
