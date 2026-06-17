using System;
class CompareWhileAndFormula{
    static void Main()
{
    int number = int.Parse(Console.ReadLine());

    //checking for natural numbers.
    if(number>=0){
        int formulaSum = (number*(number+1))/2;
        int whileSum = 0;

        //calculating sum of n natural numbers using while loop.
        while(number!=0)
        {
            whileSum+=number;
            number--;
        }
        //checking and printing if formula and while loop method are giving same results or not.
        if(whileSum==formulaSum)
        {
            Console.WriteLine($"Formula and while loop both are giving correct results {whileSum}");
        }
    }
    else{
        Console.WriteLine($"The number {number} is not a natural number");
    }
}
}