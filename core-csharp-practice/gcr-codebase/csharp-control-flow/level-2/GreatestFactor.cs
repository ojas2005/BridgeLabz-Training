using System;
class GreatestFactor{
    static void Main()
    {
        //taking number as input and setting greatestFactor as 1 because 1 is the factor of all.
        int number = int.Parse(Console.ReadLine());
        int greatestFactor = 1;

        //taking a backward loop (10 9 8 7...)
        for(int i=number-1;i>=1;i--)
        {
            //if number is divisible by i then we break the loop and set greatest factor as i.
            if(number%i==0)
            {
                greatestFactor = i;
                break;

            }
    }

    //printing greatest factor.
    Console.WriteLine(greatestFactor);
    }
}