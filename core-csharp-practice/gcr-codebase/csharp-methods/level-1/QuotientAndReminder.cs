//ques 1. Write a program to take 2 numbers and print their quotient and remainder
using System;
class QuotientAndRemainder
{
    public static int[] FindRemainderAndQuotient(int number, int divisor){
        int[] result = new int[2];
        //performing division and modulus operations
        result[0] = number/divisor;
        result[1]= number%divisor;
        return result;
    }

    static void Main()
    {
        //taking numbe and divisor as input from user.
       int number = int.Parse(Console.ReadLine());
       int divisor = int.Parse(Console.ReadLine());

       //calling our method
       int[] result = FindRemainderAndQuotient(number,divisor);
     
       //printing the results
       Console.WriteLine($"The Quotient is {result[0]} and Remainder is {result[1]} of two numbers {number} and {divisor} ");


    }
}
