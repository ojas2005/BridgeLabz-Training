using System;
class MultiplicationFromSixToNine{
    static void Main()
    {
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());
        int[] multiplication = new int[10];

        //using for loop from 6 till 9
        for(int i = 6;i<=9;i++)
        {
            multiplication[i] = number*i; //mul = number * 6 then number * 7...
            Console.WriteLine($"{number} * {i} ={multiplication[i]}"); //printing the results.
            
        }
    }
}