using System;
class LeapYear{
    static void Main()
    {
        //Taking the Year as input
        int year = int.Parse(Console.ReadLine());

        //checking if year corresponds to the Gregorian calendar.
        if(year >= 1582)
        {
            //checking the condition for leap year.
            if((year%4==0 && year%100!=0) || year%400==0)
            {
                //if the above condition is true then printing that its a leap year
                Console.WriteLine("Leap Year");
            }
        }
        else{
            //if its not a leap year then printing not a leap year.
            Console.WriteLine("Not a leap year");
        }
    }
}