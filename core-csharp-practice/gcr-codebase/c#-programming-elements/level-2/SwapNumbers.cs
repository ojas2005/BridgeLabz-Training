using System;
class SwapNumbers
{
    static void Main()
    {
        //taking number 1 and number 2 as input from user.
       int number1 = int.Parse(Console.ReadLine());
       int number2 = int.Parse(Console.ReadLine());

       //Swapping numbers
       int temp = number1;
       number1 = number2;
       number2 = temp;

       //printing the results
       Console.WriteLine($"The swapped numbers are {number1} and {number2}");
    }
}