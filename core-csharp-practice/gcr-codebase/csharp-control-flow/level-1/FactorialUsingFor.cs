using System;
class FactorialUsingWhile{
    static void Main()
    { 
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());
        int fact=1; //setting the value of factorial as 1.

        //for loop from number till 1(n*n-1*n-2....1)
        for(int i =numbe;i>0;i--)
        {
            fact*=i; //n*n-1
        }
        Console.WriteLine($"{fact}"); //printing results
    }
}