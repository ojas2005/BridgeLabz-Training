using System;
    class Factorial{
        static int factorial(int n)
        {
            int sum = 0;
            if(n==0||n==1)
            {
                return 1;
            }
            else
            {
               return n*factorial(n-1);
            }
            
        }
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int result= factorial(number);
            Console.WriteLine(result);
        }
    }
