using System;
class PositiveNegativeZero{

    public static int TypeOfInteger(int number)
    {
        //if number is greater than 0 its positive
        if(number > 0)
        {
            return 1;

        }
        //if number is zero then printing zero
        else if(number == 0)
        {
            return 0;

        }

        //apart from above cases every digit is negative.
        else{
            return -1;
        }
    }
    static void Main()
    {
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(TypeOfInteger(number));

        

    }
}