using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class PeakElement_Binary
	{
		static void Main(String[] args)
		{
			int[] peak={1,3,20,4,1};
			int left=0, right=peak.Length-1;

			while(left<right)
			{
				int middle=(left+right)/2;
				if(peak[middle]<peak[middle+1])
					left=middle+1;
				else
					right=middle;
			}

			Console.WriteLine(peak[left]);
		}
	}
}
