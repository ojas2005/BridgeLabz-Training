using System;
class FactorialUsingWhile{
    static void Main()
    {
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());
        int fact=1; //setting factorial value as 1.
        while(number>0) //using while loop till number is greater than 0.
        {
            fact *= number; //1*number next time 1*number*number-1....
            number--; //decrementing the value of number by 1.

        }
        Console.WriteLine($"{fact}"); //printing results.
    }
}