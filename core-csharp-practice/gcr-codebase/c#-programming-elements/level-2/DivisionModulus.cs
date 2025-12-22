//ques 1. Write a program to take 2 numbers and print their quotient and remainder
using System;
class DivisionModulus
{
    static void Main()
    {
        //taking number 1 and number 2 as input from user.
       int number1 = int.Parse(Console.ReadLine());
       int number2 = int.Parse(Console.ReadLine());

       //performing division and modulus operations
       float quotient = (float)number1/number2;
       int remainder = number1%number2;

       //printing the results
       Console.WriteLine($"The Quotient is {quotient} and Remainder is {remainder} of two numbers {number1} and {number2} ");


    }
}
