using System;
class KilometersToMiles{
    static void Main(){
        float kiloMeters = 10.8f; //Taking Value to Kilometers as input
        float miles = kiloMeters*0.621371f; //Converting Kilometers into miles.
        Console.WriteLine($"The distance {kiloMeters} km in miles is {miles}"); //Printing the results.
    }
}