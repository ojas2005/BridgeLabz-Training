using System;
class FeetToYardsAndMiles{
    static void Main()
    {
        float distanceInFeet = float.Parse(Console.ReadLine()); //Taking distance as input(in feet)
        float distanceInMiles = distanceInFeet/3f; //Converting distance in Miles
        float distanceInYards = distanceInMiles*1760f; //Converting distance in Yards
        Console.WriteLine($"Your distance in feet is {distanceInFeet} while in miles is {distanceInMiles} and yards is {distanceInYards}");
    }
}