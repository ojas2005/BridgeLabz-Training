using System;
class Multiplication{
    static void Main()
    {
        //taking number as input and initialising multiplication array with size 10.
        int number = int.Parse(Console.ReadLine());
        int[] multiplication = new int[10];

        //calculating and printing the multiplication table.
        for(int i = 1;i<=multiplication.Length;i++)
        {
            multiplication[i]=number*i;
            Console.WriteLine($"{number} * {i} = {multiplication[i]} ");
        }
        
    }
}