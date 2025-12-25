using System;
class UnitConversionII
   {
       static void Main(String[] args)
       {
           // Taking Input from user
           double number1 = double.Parse(Console.ReadLine());
           double number2 = double.Parse(Console.ReadLine());
           double number3 = double.Parse(Console.ReadLine());
           double number4 = double.Parse(Console.ReadLine());
           Console.WriteLine("meter to inches " +  MeterToInches(number1) + " inches to meter " +  InchesToMeter(number2) + " inches to cm" +  InchesToCm(number2) + " Yard to Feet " +  YardToFeet(number3) + " feet to Yard" +  FeetToYard(number4));
       }

       // Conversion methods
       public static double MeterToInches(double number1)
       {
           return number1 * 39.3701;
       }
        public static double InchesToMeter(double number2)
       {
           return number2 * 0.0254;
       }
       public static double InchesToCm(double number2)
       {
           return number2 * 2.54;
       }
       public static double YardToFeet(double number3)
       {
           return number3 * 3;
       }
       public static double FeetToYard(double number4)
       {
           return number4 * 0.333333;
       }
   }
