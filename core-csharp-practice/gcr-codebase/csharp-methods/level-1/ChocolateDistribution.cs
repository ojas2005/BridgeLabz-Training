using System;
class ChocolateDistribution{

     public static int[] FindRemainderAndQuotient(int number,int divisor){
        int[] result = new int[2];
        //performing division and modulus operations
        result[0] = number/divisor;
        result[1]= number%divisor;
        return result;

     }

    static void Main()
    {
        //taing number of chocolates and number of children as input.
        int numberOfChocolates = int.Parse(Console.ReadLine());
        int numberOfChildrens = int.Parse(Console.ReadLine());

        //Calculating numbers of chocolates which will be remaining after distributing pens equally.
        int[] result = FindRemainderAndQuotient(numberOfChocolates,numberOfChildrens);
             
        
        Console.WriteLine($"The number of chocolates each child gets is {result[0]} and the number of remaining chocolates is {result[1]}");
    }
}