using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class person
    {
        public int num { get; set; }
        public string nm { get; set; }
        public int pts { get; set; }

        public person(int num, string nm, int pts)
        {
            this.num=num;
            this.nm=nm;
            this.pts=pts;
        }

        public override string ToString()
        {
            return $"roll no: {num}\nname: {nm}\npoints: {pts}";
        }
    }

    internal class sort1
    {
        static void arrange(person[] arr)
        {
            for(int i=0; i<arr.Length-1; i++)
            {
                int min=i;
                for(int j=i+1; j<arr.Length; j++)
                {
                    if(arr[j].pts<arr[min].pts)
                    {
                        min=j;
                    }
                }
                if(min!=i)
                {
                    person t=arr[i];
                    arr[i]=arr[min];
                    arr[min]=t;
                }
            }
        }

        static void Main(string[] args)
        {
            person[] arr=new person[5];

            for(int i=0; i<arr.Length; i++)
            {
                int num=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                int pts=Convert.ToInt32(Console.ReadLine());
                arr[i]=new person(num, nm, pts);
            }

            Console.WriteLine("\nBefore Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            arrange(arr);

            Console.WriteLine("\nAfter Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
