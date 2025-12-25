using System;
class QuadraticOperations 
   {
       static void Main(String[] args)
       {
           // input the value a, b and c
           double a = double.Parse(Console.ReadLine());
           double b = double.Parse(Console.ReadLine());
           double c = double.Parse(Console.ReadLine());
           // calculating delta values
           double delta = Math.Pow(b, 2) - 4 * a * c;
           double[] roots =  Roots(a, b, delta);
           if (roots.Length == 1)
           {
               Console.WriteLine("one root " + roots[0]);
           }
           
           else if (roots.Length == 2)
           {
               Console.WriteLine(roots[0] + " and " + roots[1]);
           }
           else
           {
               Console.WriteLine("no roots.");
           }
       }

       public static double[] Roots(double a, double b, double delta)
       {
           // calculate roots based on delta value
           if (delta > 0)
           {
               double root1 = (-b + delta) / (2 * a);
               double root2 = (-b - delta) / (2 * a);
               return new double[] { root1, root2 };
           }
           else if (delta == 0)
           {
               double root1 = -b / (2 * a);
               return new double[] { root1 };
           }
           else
           {
               return new double[0];

           }
       }
   }
