using System;
class KilometersToMiles{
    static void Main(){
        float kilometers = float.Parse(Console.ReadLine()); //Taking Value to Kilometers as input
        float miles = kilometers*0.621371f; //Converting Kilometers into miles.
        Console.WriteLine(miles); //Printing the results.
    }
}