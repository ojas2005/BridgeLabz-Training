using System;
class CountTheDigits{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());
        int digits = 0;
        //if the number is 0 then there is 1 digit.
        if(number==0)
        {
            digits=1;
        }
        else{
            //dividing the number by 10 repeatedly to get 1 digit out each time.
        while(number!=0)
        {
            number = number/10;
            digits++;

        }
    }
        //printing the results.
        
        Console.WriteLine(digits);
    }
}