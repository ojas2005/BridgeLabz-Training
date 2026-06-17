using System;
class CompareWhileAndFormula{
    static void Main()
{   
    //taking number as input.
    int number = int.Parse(Console.ReadLine());

    //checking for natural numbers.
    if(number>=0){

        //calculating sum of n natural numbers using formula
        int formulaSum = (number*(number+1))/2;
        int forSum = 0;

        //calculating sum of n natural numbers using for loop.
        for(int i = number;i>0;i--)
        {
            forSum+=i;
        }

        //checking and printing if formula and for loop method are giving same results or not.
        if(forSum==formulaSum)
        {
            Console.WriteLine($"Formula and for loop both are giving correct results {forSum}");
        }
    }
    else{
        Console.WriteLine($"The number {number} is not a natural number");
    }
}
}