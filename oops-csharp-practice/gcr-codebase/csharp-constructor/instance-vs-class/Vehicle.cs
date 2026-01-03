using System;

class Vehicle
{
    string ownerName;
    string vehicleType;
    static double registrationFee=5000; //our class variabe

    // Creating our Constructor
    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName=ownerName;
        this.vehicleType=vehicleType;
    }

    //Display Method to display details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner name is {ownerName}" );
        Console.WriteLine($"Vehicle type is {vehicleType}");
        Console.WriteLine($"Registration fee is {registrationFee}");
    }
    //creating our method to update registration fee
    public static void UpdateRegistrationFee(double feeAfterUpdate)
    {
        registrationFee=feeAfterUpdate;
        Console.WriteLine($"Registration fees updated successfully,New registration fee is {registrationFee}");
    }
}
