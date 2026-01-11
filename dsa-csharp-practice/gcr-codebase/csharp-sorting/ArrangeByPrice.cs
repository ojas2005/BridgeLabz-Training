using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class book
    {
        public int id { get; set; }
        public string ttl { get; set; }
        public double pr { get; set; }

        public book(int id, string ttl, double pr)
        {
            this.id=id;
            this.ttl=ttl;
            this.pr=pr;
        }

        public override string ToString()
        {
            return $"book id: {id}\ntitle: {ttl}\nprice: {pr}";
        }
    }

    internal class sort6
    {
        static void arrange(book[] arr, int lft, int rgt)
        {
            if(lft<rgt)
            {
                int mid=(lft+rgt)/2;
                arrange(arr, lft, mid);
                arrange(arr, mid+1, rgt);
                combine(arr, lft, mid, rgt);
            }
        }

        static void combine(book[] arr, int lft, int mid, int rgt)
        {
            int n1=mid-lft+1;
            int n2=rgt-mid;

            book[] a=new book[n1];
            book[] b=new book[n2];

            for(int i=0; i<n1; i++)
                a[i]=arr[lft+i];

            for(int j=0; j<n2; j++)
                b[j]=arr[mid+1+j];

            int x=0, y=0;
            int k=lft;

            while(x<n1&&y<n2)
            {
                if(a[x].pr<=b[y].pr)
                {
                    arr[k]=a[x];
                    x++;
                }
                else
                {
                    arr[k]=b[y];
                    y++;
                }
                k++;
            }

            while(x<n1)
            {
                arr[k]=a[x];
                x++;
                k++;
            }

            while(y<n2)
            {
                arr[k]=b[y];
                y++;
                k++;
            }
        }

        static void Main(string[] args)
        {
            book[] arr=new book[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string ttl=Console.ReadLine();
                double pr=Convert.ToDouble(Console.ReadLine());
                arr[i]=new book(id, ttl, pr);
            }

            Console.WriteLine("\nBefore Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            arrange(arr, 0, arr.Length-1);

            Console.WriteLine("\nAfter Sorting");
            for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
