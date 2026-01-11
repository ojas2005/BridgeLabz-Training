using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class worker
    {
        public int id { get; set; }
        public string nm { get; set; }

        public worker(int id, string nm)
        {
            this.id=id;
            this.nm=nm;
        }

        public override string ToString()
        {
            return $"worker id: {id}\nname: {nm}";
        }
    }

    internal class sort4
    {
        static void arrange(worker[] arr)
        {
            for(int i=1; i<arr.Length; i++)
            {
                worker key=arr[i];
                int j=i-1;

                while(j>=0&&arr[j].id>key.id)
                {
                    arr[j+1]=arr[j];
                    j--;
                }
                arr[j+1]=key;
            }
        }

        static void Main(string[] args)
        {
            worker[] arr=new worker[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                arr[i]=new worker(id, nm);
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
