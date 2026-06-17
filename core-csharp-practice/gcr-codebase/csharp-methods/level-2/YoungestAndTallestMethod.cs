using System;
class YoungestAndTallestMethod
   {
        //creating methods
        public static int Youngest(int age1, int age2, int age3)
       {
           return Math.Min(age1, Math.Min(age2, age3));
       }

       public static int Tallest(int height1, int height2, int height3)
       {
           return Math.Max(height1, Math.Max(height2, height3));
       }
           static void Main(String[] args)
       {// taking age input from user
           int age1 = int.Parse(Console.ReadLine());
           int age2 = int.Parse(Console.ReadLine());
           int age3 = int.Parse(Console.ReadLine());
            // taking height input from user
           int height1 = int.Parse(Console.ReadLine());
           int height2 = int.Parse(Console.ReadLine());
           int height3 = int.Parse(Console.ReadLine());

          
           Console.WriteLine("The Yougest one is " + Youngest(age1, age2, age3) + " year old and the tallest one is " + Tallest(height1, height2, height3) + " cm");
       }
       

   }
