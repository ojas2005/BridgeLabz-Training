using System;
class LeapYearMethod
   {
       static void Main(String[] args)
       {
           
           int year = int.Parse(Console.ReadLine());
           
           Console.WriteLine(LeapYearOrNot(year));
       }

       public static String LeapYearOrNot(int year)
       {
           // A year is a leap year if it is divisible by 4 but not by 100,
           if (year >= 1582 && (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)))
           {
               return "year is a leap year";
           }
           else
           {
               return "year is not a leap year";
           }
       }
   }
