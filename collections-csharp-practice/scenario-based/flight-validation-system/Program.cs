using System;

public class UserInterface
{
    public static void Main()
    {
        FlightUtil flightUtil = new FlightUtil();
        
        Console.WriteLine("Enter flight details");
        string input = Console.ReadLine();
        
        try
        {
            string[] details = input.Split(':');
            
            string flightNumber = details[0];
            string flightName = details[1];
            int passengerCount = int.Parse(details[2]);
            double currentFuelLevel = double.Parse(details[3]);
            
            flightUtil.ValidateFlightNumber(flightNumber);
            flightUtil.ValidateFlightName(flightName);
            flightUtil.ValidatePassengerCount(passengerCount, flightName);
            
            double fuelRequired = flightUtil.CalculateFuelToFillTank(flightName, currentFuelLevel);
            
            Console.WriteLine($"Fuel required to fill the tank: {fuelRequired} liters");
        }
        catch (InvalidFlightException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
