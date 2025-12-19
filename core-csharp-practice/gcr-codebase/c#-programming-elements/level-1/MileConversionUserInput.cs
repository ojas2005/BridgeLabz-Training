using System;
class KilometersToMiles{
    static void Main(){
        float kiloMeters = float.Parse(Console.ReadLine()); //Taking Value to Kilometers as input
        float miles = kiloMeters*0.621371f; //Converting Kilometers into miles.
        Console.WriteLine($"The total miles is {miles} mile for the given {kiloMeters} km"); //Printing the results.
    }
}