using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class student
    {
        public int id { get; set; }
        public string nm { get; set; }
        public int marks { get; set; }

        public student(int id, string nm, int marks)
        {
            this.id=id;
            this.nm=nm;
            this.marks=marks;
        }

        public override string ToString()
        {
            return $"id: {id}\nname: {nm}\nmarks: {marks}";
        }
    }

    internal class sort5
    {
        static void arrange(student[] arr)
        {
            int sz=arr.Length;
            bool chg;

            for(int i=0; i<sz-1; i++)
            {
                chg=false;

                for(int j=0; j<sz-i-1; j++)
                {
                    if(arr[j].marks>arr[j+1].marks)
                    {
                        student t=arr[j];
                        arr[j]=arr[j+1];
                        arr[j+1]=t;
                        chg=true;
                    }
                }

                if(!chg)
                    break;
            }
        }

        static void Main(string[] args)
        {
            student[] arr=new student[5];

            for(int i=0; i<arr.Length; i++)
            {
                int id=Convert.ToInt32(Console.ReadLine());
                string nm=Console.ReadLine();
                int marks=Convert.ToInt32(Console.ReadLine());
                arr[i]=new student(id, nm, marks);
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
