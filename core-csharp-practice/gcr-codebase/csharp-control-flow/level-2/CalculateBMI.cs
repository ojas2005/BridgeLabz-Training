using System;
class CalculateBMI{
    static void Main()
    {

        //taking weight and height as input.
        double weight = double.Parse(Console.ReadLine());
        double heightInCm = double.Parse(Console.ReadLine());

        //converting heightin cm to height in meter.
        double heightInMeter = heightInCm/100d;

        //calculating BMI
        double bmi = weight/(heightInMeter*heightInMeter);
       
        //categorising the results.
        if(bmi<=18.4){
        Console.WriteLine("Underweight");
        }
        else if(bmi>18.4 && bmi<=24.9){
        Console.WriteLine("Normal");
        }
        else if(bmi>24.9 && bmi<=39.9){
        Console.WriteLine("Overweight");
        }
        else{
            Console.WriteLine("Obese");
        }

    }
}