using System;
class VolumeOfCylinder
{
    static void Main()
    {
        float radius = float.Parse(Console.ReadLine()); //Taking Radius as input
        float h = float.Parse(Console.ReadLine()); //Taking height as input
        float pi = 3.14f;
        float vol = pi * radius * radius * h; //Calculating the volume
        Console.WriteLine(vol); //Printing the results
    }
}