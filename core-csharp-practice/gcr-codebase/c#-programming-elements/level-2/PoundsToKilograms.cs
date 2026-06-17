using System;
class PoundsToKilograms{
    static void Main()
    {
        //taking weight  in pounds as input
        double weightInPounds = double.Parse(Console.ReadLine());

        //converting pounds in kilograms
        double weightInKilograms = weightInPounds*2.2;

        //printing the results.
        Console.WriteLine($"The weight of the person in pounds is {weightInPounds} and in kg it is {weightInKilograms}");
    }
}