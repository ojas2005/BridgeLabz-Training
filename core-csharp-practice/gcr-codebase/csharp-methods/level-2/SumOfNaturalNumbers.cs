using System;
class SumOfNaturalNumbers
   {
       static void Main(String[] arggs)
       {
           
           int number = int.Parse(Console.ReadLine());
           int formulaAnswer = (number * (number + 1)) / 2;
           if (formulaAnswer == SumOfNaturalNumbers(number))
           {
               Console.WriteLine("both are equals");
           }
           else
           {
               Console.WriteLine("not equal");
           }

       }

       public static int SumOfNaturalNumbers(int  number)
       {
           // Base case
           if ( number == 1)
           {
               return 1;
           }
           else
           {
               // Recursive case
               return  number + SumOfNaturalNumbers( number - 1);
           }


       }
   }

