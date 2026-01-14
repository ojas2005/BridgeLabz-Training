using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class RotationPoint_Binary
	{
		static void Main(String[] args)
		{
			int[] rotated={4,5,6,7,1,2,3};
			int first=0, last=rotated.Length-1;

			while(first<last)
			{
				int mid=(first+last)/2;
				if(rotated[mid]>rotated[last])
					first=mid+1;
				else
					last=mid;
			}

			Console.WriteLine(first);
		}
	}
}
