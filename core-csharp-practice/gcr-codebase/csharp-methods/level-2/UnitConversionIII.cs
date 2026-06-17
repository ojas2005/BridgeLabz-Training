using System;
class UnitConversionIII
   {
       static void Main(String[] args)
       {
           //  Input from user
           double number1 =  double.Parse(Console.ReadLine());
           double number2 =  double.Parse(Console.ReadLine());
           double number3 =  double.Parse(Console.ReadLine());
           double number4 =  double.Parse(Console.ReadLine());
           double number5 =  double.Parse(Console.ReadLine());
           double number6 =  double.Parse(Console.ReadLine());
           Console.WriteLine( FarhenheitToCelsius(number1) + " " +  FarhenheitToCelsius(number1) + " " +  CelsiusToFarhenheit(number2) + " " +  PoundsToKilograms(number3) + " " +  KilogramsToPounds(number4) + " " +  LitersToGallons(number5) +" "+  GallonsToLiters(number6));
       }
       // Method for Unit Conversion
       double FarhenheitToCelsius(double number1)
       {
           return (number1 - 32) * 5 / 9;
       }
       double CelsiusToFarhenheit(double number2)
       {
           return (number2 * 9 / 5) + 32;
       }
       double PoundsToKilograms(double number3)
       {
           return number3 * 0.453592;
       }
       double KilogramsToPounds(double number4)
       {
           return number4 * 2.20462;
       }
       double GallonsToLiters(double number5)
       {
           return number5 * 3.78541;
       }
       double LitersToGallons(double number6)
       {
           return number6 * 0.264172;
       }
   }
