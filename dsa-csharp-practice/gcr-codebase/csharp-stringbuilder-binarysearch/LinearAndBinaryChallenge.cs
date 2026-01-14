using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_stringbuildle_binarysearch_filereader
{
	internal class LinearAndBinaryChallenge
	{
		static void Main(String[] args)
		{
			int[] sequence={3,4,-1,1};

			bool[] exists=new bool[sequence.Length+1];
			foreach(int x in sequence)
			{
				if(x>0&&x<=sequence.Length)
					exists[x]=true;
			}

			for(int j=1;j<exists.Length;j++)
			{
				if(!exists[j])
				{
					Console.WriteLine("absent: "+j);
					break;
				}
			}

			Array.Sort(sequence);
			int look=4;
			int pos=Array.BinarySearch(sequence,look);
			Console.WriteLine(pos>=0?pos:-1);
		}
	}
}
