using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class item
    {
        public int id { get; set; }
        public string nm { get; set; }
        public double pr { get; set; }

        public item(int id, string nm, double pr)
        {
            this.id=id;
            this.nm=nm;
            this.pr=pr;
        }

        public override string ToString()
        {
            return $"item id: {id}\nname: {nm}\nprice: {pr}";
        }
    }

    internal class sort2
    {
        static void organize(item[] arr, int start, int end)
        {
            if(start<end)
            {
                int p=split(arr, start, end);
                organize(arr, start, p-1);
                organize(arr, p+1, end);
            }
        }

        static int split(item[] arr, int start, int end)
        {
            double pv=arr[end].pr;
            int k=start-1;
            for(int j=start; j<end; j++)
            {
                if(arr[j].pr<pv)
                {
                    k++;
                    item t=arr[k];
                    arr[k]=arr[j];
                    arr[j]=t;
                }
            }
            item t1=arr[k+1];
            arr[k+1]=arr[end];
            arr[end]=t1;
            return k+1;
        }

        static void Main(string[] args)
        {
            item[] arr=new item[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                double pr=Convert.ToDouble(Console.ReadLine());
                arr[i]=new item(id, nm, pr);
            }

            Console.WriteLine("\nBefore Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            organize(arr, 0, arr.Length-1);

            Console.WriteLine("\nAfter Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
