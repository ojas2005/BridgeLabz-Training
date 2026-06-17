using System;
    class FactorialUsingRecursion{
        static void factorial(int n)
        {
            int sum = 0;
            while(n>0)
            {
                sum+= (n*(n-1));
                factorial(n-1);
            }
            Console.WriteLine(sum);
        }
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            factorial(number);
        }
    }
