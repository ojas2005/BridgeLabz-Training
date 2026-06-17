using System;
class VolumeOfEarth{
    static void Main()
    {
        //taking radius of earth in kms and value of pi
        int radiusOfEarth = 6378;
        float pi = 3.14;

        //calculating the volume in kilometers then converting it into miles.
        double VolumeInKilometers = (4/3)*pi*radiusOfEarth*radiusOfEarth*radiusOfEarth;
        double VolumeInMiles = VolumeInKilometers*0.621371;

        //printing the results.
        Console.WriteLine($"The volume of earth in cubic kilometers is {VolumeInKilometers} cubic miles is {VolumeInMiles}");
    }
}