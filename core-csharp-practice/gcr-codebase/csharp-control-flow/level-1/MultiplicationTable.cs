using System;
class Multiplicationtable{
    static void Main()
    {
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());

        //using for loop from 6 till 9
        for(int i = 6;i<=9;i++)
        {
            int mul = number*i; //mul = number * 6 then number * 7...
            Console.WriteLine($"{number} * {i} ={mul}"); //printing the results.
            mul=0; //setting value of mul to 0 for next iteration.
        }
    }
}