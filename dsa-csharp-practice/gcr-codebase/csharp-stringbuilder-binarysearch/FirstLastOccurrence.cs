using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class FirstLastOccurrence
	{
		static void Main(String[] args)
		{
			int[] numbers={1,2,2,2,3,4};
			int search=2;

			int initial=-1, final=-1;

			for(int i=0;i<numbers.Length;i++)
			{
				if(numbers[i]==search)
				{
					if(initial==-1) initial=i;
					final=i;
				}
			}

			Console.WriteLine($"{initial},{final}");
		}
	}
}
