using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class boy
    {
        public int id { get; set; }
        public string nm { get; set; }
        public int age { get; set; }

        public boy(int id, string nm, int age)
        {
            this.id=id;
            this.nm=nm;
            this.age=age;
        }

        public override string ToString()
        {
            return $"id: {id}\nname: {nm}\nage: {age}";
        }
    }

    internal class sort3
    {
        static void arrange(boy[] arr)
        {
            int lower=10;
            int upper=18;
            int rng=upper-lower+1;
            int[] cnt=new int[rng];
            boy[] out_arr=new boy[arr.Length];

            for(int i=0; i<arr.Length; i++)
            {
                cnt[arr[i].age-lower]++;
            }

            for(int i=1; i<cnt.Length; i++)
            {
                cnt[i]=cnt[i]+cnt[i-1];
            }

            for(int i=arr.Length-1; i>=0; i--)
            {
                int idx=arr[i].age-lower;
                out_arr[cnt[idx]-1]=arr[i];
                cnt[idx]--;
            }

            for(int i=0; i<arr.Length; i++)
            {
                arr[i]=out_arr[i];
            }
        }

        static void Main(string[] args)
        {
            boy[] arr=new boy[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                int age=Convert.ToInt32(Console.ReadLine());
                arr[i]=new boy(id, nm, age);
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
