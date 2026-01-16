using System;

public class Vehicle
{
	public string VehicleNumber{get;set;}
	public string OwnerName{get;set;}
	public Vehicle Next{get;set;}

	public Vehicle(string vehicleNumber,string ownerName)
	{
		VehicleNumber=vehicleNumber;
		OwnerName=ownerName;
		Next=null;
	}

	public void DisplayInfo()
	{
		Console.WriteLine($"vehicle number:- {VehicleNumber}, owner name:- {OwnerName}");
	}
}
