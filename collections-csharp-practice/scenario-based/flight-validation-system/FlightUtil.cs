using System;
using System.Text.RegularExpressions;

public class FlightUtil
{
    public bool ValidateFlightNumber(string flightNumber)
    {
        Regex regex = new Regex(@"^FL-\d{4}$");
        
        if (!regex.IsMatch(flightNumber))
        {
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
        }
        
        int numberPart = int.Parse(flightNumber.Substring(3));
        
        if (numberPart < 1000 || numberPart > 9999)
        {
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
        }
        
        return true;
    }

    public bool ValidateFlightName(string flightName)
    {
        string[] validFlights = { "SpiceJet", "Vistara", "IndiGo", "Air Arabia" };
        
        foreach (string flight in validFlights)
        {
            if (flight.Equals(flightName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        
        throw new InvalidFlightException($"The flight name {flightName} is invalid");
    }

    public bool ValidatePassengerCount(int passengerCount, string flightName)
    {
        int maxCapacity = GetMaxPassengerCapacity(flightName);
        
        if (passengerCount <= 0 || passengerCount > maxCapacity)
        {
            throw new InvalidFlightException($"The passenger count {passengerCount} is invalid for {flightName}");
        }
        
        return true;
    }

    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuelCapacity = GetMaxFuelCapacity(flightName);
        
        if (currentFuelLevel < 0 || currentFuelLevel > maxFuelCapacity)
        {
            throw new InvalidFlightException($"Invalid fuel level for {flightName}");
        }
        
        return maxFuelCapacity - currentFuelLevel;
    }

    private int GetMaxPassengerCapacity(string flightName)
    {
        switch (flightName)
        {
            case "SpiceJet":
                return 396;
            case "Vistara":
                return 615;
            case "IndiGo":
                return 230;
            case "Air Arabia":
                return 130;
            default:
                return 0;
        }
    }

    private double GetMaxFuelCapacity(string flightName)
    {
        switch (flightName)
        {
            case "SpiceJet":
                return 200000;
            case "Vistara":
                return 300000;
            case "IndiGo":
                return 250000;
            case "Air Arabia":
                return 150000;
            default:
                return 0;
        }
    }
}
