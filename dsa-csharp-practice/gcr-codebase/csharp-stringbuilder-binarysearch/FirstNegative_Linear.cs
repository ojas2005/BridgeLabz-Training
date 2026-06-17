using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class FirstNegative_Linear
	{
		static void Main()
		{
			int[] values={5,3,-2,7,-1};

			foreach(int num in values)
			{
				if(num<0)
				{
					Console.WriteLine(num);
					break;
				}
			}
		}
	}
}
