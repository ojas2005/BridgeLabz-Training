using System;
class PositiveNegativeZero{
    static void Main()
    {
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());

        //if number is greater than 0 its positive
        if(number > 0)
        {
            Console.WriteLine("Positive");

        }
        //if number is zero then printing zero
        else if(number == 0)
        {
            Console.WriteLine("Zero");

        }

        //apart from above cases every digit is negative.
        else{
            Console.WriteLine("Negative");
        }
    }
}