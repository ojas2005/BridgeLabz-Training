using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("Roundabout Traffic Manager");

		Roundabout trafficManager=new Roundabout(5);
		bool running=true;

		while(running)
		{
			DisplayMenu();
			Console.Write(" ");
			string choice=Console.ReadLine();

			switch(choice)
			{
				case "1":
					AddVehicleToQueue(trafficManager);
					break;

				case "2":
					AllowVehicleEntry(trafficManager);
					break;

				case "3":
					RemoveVehicle(trafficManager);
					break;

				case "4":
					trafficManager.DisplayAllStatus();
					break;

				case "5":
					RunCodeWithFixedData(trafficManager);
					break;

				case "6":
					Console.WriteLine(" ");
					running=false;
					break;

				default:
					Console.WriteLine("please enter a valid choice.");
					break;
			}
		}
	}

	static void DisplayMenu()
    {
        Console.WriteLine("\nMAIN MENU");
        Console.WriteLine("press 1 to add vehicle to waiting queue");
        Console.WriteLine("press 2 to allow vehicle to enter the roundabout");
        Console.WriteLine("press 3 to remove vehicle from the roundabout");
        Console.WriteLine("press 4 to display roundabout status");
        Console.WriteLine("press 5 to run code with fixed data values(without filling details manually)");
        Console.WriteLine("press 6 to exit");
    }


	static void AddVehicleToQueue(Roundabout trafficManager)
	{
		Console.Write("enter owner name: ");
		string ownerName=Console.ReadLine();

		if(string.IsNullOrWhiteSpace(ownerName))
		{
			Console.WriteLine("please enter a valid name.");
			return;
		}
		trafficManager.AddVehicleToQueue(ownerName);
	}

	static void AllowVehicleEntry(Roundabout trafficManager)
	{
		Console.WriteLine("");
		trafficManager.AllowVehicleToEnter();
	}

	static void RemoveVehicle(Roundabout trafficManager)
	{
		Console.WriteLine("");
		trafficManager.RemoveVehicleFromRoundabout();
	}

	static void RunCodeWithFixedData(Roundabout trafficManager)
	{
		Console.WriteLine("Fixed data code output");

		Console.WriteLine("we are taking 8 vehicles to enter");
		trafficManager.AddVehicleToQueue("rajesh kumar");
		trafficManager.AddVehicleToQueue("priya singh");
		trafficManager.AddVehicleToQueue("anil patel");
		trafficManager.AddVehicleToQueue("neha sharma");
		trafficManager.AddVehicleToQueue("vikram desai");
		trafficManager.AddVehicleToQueue("pooja verma");
		trafficManager.AddVehicleToQueue("arjun gupta");
		trafficManager.AddVehicleToQueue("deepika");

		trafficManager.DisplayAllStatus();
        Console.WriteLine(" ");

		Console.WriteLine("allowing 3 vehicles to enter the roundabout");
		trafficManager.AllowVehicleToEnter();
		trafficManager.AllowVehicleToEnter();
		trafficManager.AllowVehicleToEnter();

		trafficManager.DisplayAllStatus();
        Console.WriteLine(" ");

		Console.WriteLine("adding 2 more vehicles");
		trafficManager.AddVehicleToQueue("sameer khan");
		trafficManager.AddVehicleToQueue("aryan verma");


		trafficManager.DisplayAllStatus();
        Console.WriteLine(" ");

		Console.WriteLine("removing 2 vehicles from roundabout");
        
		trafficManager.RemoveVehicleFromRoundabout();
		trafficManager.RemoveVehicleFromRoundabout();

		trafficManager.DisplayAllStatus();
        Console.WriteLine(" ");

		Console.WriteLine("allowing more vehicles to enter");
        Console.WriteLine(" ");
		trafficManager.AllowVehicleToEnter();
		trafficManager.AllowVehicleToEnter();
		trafficManager.AllowVehicleToEnter();

		trafficManager.DisplayAllStatus();

		Console.WriteLine(" ");
	}
}
