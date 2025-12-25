using System;
class OperationsOnFactorsMethods
   {
       static void Main(String[] args)
       {
           int number = int.Parse(Console.ReadLine());
           int  size =  Factors(number).Length;
           int[] factors =  Factors(number);

           for (int i = 0; i <  size; i++)
           {
               Console.Write(factors[i] + " ");
           }
           Console.WriteLine();
           Console.WriteLine( SumOfFactors(factors));
           Console.WriteLine( SumOfSquafactors(factors));
           Console.WriteLine( ProductOfFactors(factors));

       }
       public static int[] Factors(int number)
       {
           // Finding factors of a number
           int index = number / 2;
           int[] fact = new int[index];
           int n = 0;
           for (int i = 1; i <= number; i++)
           {
               if (number % i == 0)
               {
                   // Resize the array if needed
                   if (n == index)
                   {
                       index = index * 2;
                       int[] temp = new int[index];
                       for (int j = 0; j < temp.Length; i++)
                       {
                           // Copy old elements to new array
                           temp[j] = fact[i];
                       }
                       fact = temp;
                   }
                   fact[n] = i;
                   n++;

               }
           }

           return fact;
       }

       public static int SumOfFactors(int[] factors)
       {
           //  Sum of factors
           int sum = 0;
           for (int i = 0; i < factors.Length; i++)
           {
               sum += factors[i];

           }
           return sum;
       }
       public static int SumOfSquafactors(int[] factors)
       {
           // Sum of square of factors
           int sum2 = 0;
           for (int i = 0; i < factors.Length; i++)
           {
               sum2 += factors[i] * factors[i];

           }
           return sum2;
       }
      public static int ProductOfFactors(int[] factors)
       {
           // Product of factors
           int product = 1;
           for (int i = 0; i < factors.Length; i++)
           {
               product *= factors[i];

           }
           return product;
       }
   }
