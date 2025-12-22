using System;
class SumOfNaturalNumbers{
    static void Main()
{
    //taking number as input.
    int number = int.Parse(Console.ReadLine());

    //checking if number is a natural number(including zero).
    if(number>=0){
        //calculating sum of n natural numbers.
        int sum = (number*(number+1))/2;

        //printing the results.
        Console.WriteLine($"The sum of {number} natural numbers is {sum}");
    }
    else{
        Console.WriteLine($"The number {number} is not a natural number");
    }
}
}