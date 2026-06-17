using System;
class AverageOfRandomMethod
   {
       static void Main(String[] args)
       {
           
           int[] number = GetRandom();
           int[] result = avg(number);
           // print the result
           Console.WriteLine("average " + result[0] + " min: " + result[1] + " max: " + result[2]);
       }

       int[] GetRandom()
       {
           // generating 5 random numbers between 1000 and 9999
           int[] number = new int[5];
           
           for (int i = 0; i < 5; i++)
           {
               //store random number in array
               number[i] = Random.Next(1000, 10000);
           }
           return number;
       }

       int[] avg(int[] number)
       {
           // calculate average, min and max
           int sum = 0;
           int min = number[0];
           int max = number[0];
           for (int i = 0; i < number.Length; i++)
           {
               sum += number[i];
               min = Math.Min(min, number[i]);
               max = Math.Max(max, number[i]);
           }

           int average = sum / number.Length;
           //return average, min and max in an array
           return new int[] { average, min, max };
       }

   }

