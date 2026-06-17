using System;
class CompareNumber
   {
       static void Main(String[] args)
       {
           // Taking 5 numbers as input from user
           int n = 5;
           int[] number = new int[n];
           
           for (int i = 0; i < n; i++)
           {
               number[i] = int.Parse(Console.ReadLine());
           }
           String[] status = IsPositiveNegativeZero(number);
           String[] finalStatus = IsEvenOrOdd(number, status);
           // Printing results
           for (int i = 0; i < n; i++)
           {
               Console.WriteLine("the number " + number[i] + " is " + finalStatus[i]);
           }
           Console.WriteLine(WhoIsGreater(number[0], number[4]));
       }

       public static String[] IsPositiveNegativeZero(int[] number)
       {
           // Determine if each number is positive, negative, or zero
           String[] status = new string[number.Length];
           for (int i = 0; i < number.Length; i++)
           {
               if (number[i] > 0)
               {
                   status[i] = "Positive";
               }
               else if (number[i] < 0)
               {
                   status[i] = "Negative";
               }
               else
               {
                   status[i] = "Zero";
               }
           }
           return status;
       }

       public static String[] IsEvenOrOdd(int[] number, String[] status)
       {
           // For positive numbers, determine if they are even or odd
           for (int i = 0; i < number.Length; i++)
           {
               if (status[i] == "Positive")
               {
                   if (number[i] % 2 == 0)
                   {
                       status[i] = "Positive Even";
                   }
                   else
                   {
                       status[i] = "Positive Odd";
                   }
               }
           }
           return status;
       }

       public static String WhoIsGreater(int number1, int number2)
       {
           // Compare two numbers and return which one is greater or if they are equal
           if (number1 > number2)
           {
               return "First is Greater";
           }
           else if (number1 < number2)
           {
               return "Second is Greater";
           }
           else
           {
               return "Both are Equal";
           }
       }
   }

