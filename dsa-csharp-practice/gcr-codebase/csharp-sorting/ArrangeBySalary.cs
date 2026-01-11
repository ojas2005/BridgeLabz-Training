using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class person_data
    {
        public int id { get; set; }
        public string nm { get; set; }
        public double sal { get; set; }

        public person_data(int id, string nm, double sal)
        {
            this.id=id;
            this.nm=nm;
            this.sal=sal;
        }

        public override string ToString()
        {
            return $"id: {id}\nname: {nm}\nsalary: {sal}";
        }
    }

    internal class sort7
    {
        static void arrange(person_data[] arr)
        {
            int sz=arr.Length;

            for(int i=sz/2-1; i>=0; i--)
            {
                heap(arr, sz, i);
            }

            for(int i=sz-1; i>0; i--)
            {
                person_data t=arr[0];
                arr[0]=arr[i];
                arr[i]=t;
                heap(arr, i, 0);
            }
        }

        static void heap(person_data[] arr, int sz, int idx)
        {
            int big=idx;
            int left=2*idx+1;
            int right=2*idx+2;

            if(left<sz&&arr[left].sal>arr[big].sal)
                big=left;

            if(right<sz&&arr[right].sal>arr[big].sal)
                big=right;

            if(big!=idx)
            {
                person_data t=arr[idx];
                arr[idx]=arr[big];
                arr[big]=t;
                heap(arr, sz, big);
            }
        }

        static void Main(string[] args)
        {
            person_data[] arr=new person_data[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                double sal=Convert.ToDouble(Console.ReadLine());
                arr[i]=new person_data(id, nm, sal);
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
