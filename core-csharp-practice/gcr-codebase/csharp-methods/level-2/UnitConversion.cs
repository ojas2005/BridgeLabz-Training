using System;
class UnitConversion
   {
       static void Main(String[] args)
       {
           // Input from user
           double number1 = double.Parse(Console.ReadLine());
           double number2 = double.Parse(Console.ReadLine());
           double number3 = double.Parse(Console.ReadLine());
           double number4 = double.Parse(Console.ReadLine());
           Console.WriteLine("Kilo to Mile: " +  KiloToMile(number1) + "Mile to kilo " +  MileToKilo(number2) + "MeterToFeet " +  MeterToFeet(number3) + " feet to meter" +  FeetToMeter(number4));
       }
       // Conversion methods

       public static double KiloToMile(double number1)
       {
           return number1 * 0.621371;
       }
       public static double MileToKilo(double number2)
       {
           return number2 * 1.60934;
       }
       public static double MeterToFeet(double number3)
       {
           return number3 * 3.28084;
       }
       public static double FeetToMeter(double number4)
       {
           return number4 * 0.3048;
       }
   }

