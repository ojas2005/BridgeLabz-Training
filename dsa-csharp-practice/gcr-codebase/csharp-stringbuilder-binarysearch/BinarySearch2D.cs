using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class BinarySearch2D
	{
		static void Main(String[] args)
		{
			int[,] data={{1,3,5},{7,9,11}};
			int seek=9;
			int totalRows=data.GetLength(0);
			int totalCols=data.GetLength(1);

			int start=0, end=totalRows*totalCols-1;

			while(start<=end)
			{
				int center=(start+end)/2;
				int val=data[center/totalCols,center%totalCols];

				if(val==seek)
				{
					Console.WriteLine("element found at position");
					return;
				}
				if(val<seek) start=center+1;
				else end=center-1;
			}

			Console.WriteLine("element not found");
		}
	}
}
