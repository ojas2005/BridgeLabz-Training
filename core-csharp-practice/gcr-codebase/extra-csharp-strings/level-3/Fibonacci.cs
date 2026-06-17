using System;
class Fibonacci
{
    static int FibonacciNumberAtN(int number)
    {
        if(number<=1)
            return number;
        int a=0;
        int b=1;
        for (int i=2;i<=number;i++)
        {
            int temp=a+b;
            a=b;
            b=temp;
        }
        return temp;
    }   
    static void Main()
    {
        Console.Write("Enter the number");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine($"The number at {number} position in fibonacci series is {FibonacciNumberAtN(number)}");
    }
}
