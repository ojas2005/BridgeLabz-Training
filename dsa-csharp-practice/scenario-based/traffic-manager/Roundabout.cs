using System;

public class Roundabout
{
	private CircularLinkedList roundabout;
	private VehicleQueue waitingQueue;
	private int vehicleCounter;

	public Roundabout(int queueCapacity)
	{
		roundabout=new CircularLinkedList();
		waitingQueue=new VehicleQueue(queueCapacity);
		vehicleCounter=0;
	}

	public void AddVehicleToQueue(string ownerName)
	{
		vehicleCounter++;
		string vehicleId=$"v{vehicleCounter}";
		Vehicle vehicle=new Vehicle(vehicleId,ownerName);
		waitingQueue.Enqueue(vehicle);
	}

	public void AllowVehicleToEnter()
	{
		if(waitingQueue.IsEmpty())
		{
			Console.WriteLine("no vehicles in queue to allow entry");
			return;
		}

		Vehicle vehicle=waitingQueue.Dequeue();
		if(vehicle!=null)
		{
			roundabout.AddVehicle(vehicle);
		}
	}

	public void RemoveVehicleFromRoundabout()
	{
		if(roundabout.IsEmpty())
		{
			Console.WriteLine("roundabout is empty,no vehicles to remove");
			return;
		}

		roundabout.RemoveVehicle();
	}

	public void DisplayAllStatus()
	{
        Console.WriteLine("traffic manager:");
		roundabout.DisplayRoundabout();
		waitingQueue.DisplayQueue();
    	Console.WriteLine($"total vehicles:-{roundabout.GetCount()+waitingQueue.GetCount()}");
		Console.WriteLine($"vehicles in roundabout:- {roundabout.GetCount()}");
		Console.WriteLine($"vehicles waiting in queue:- {waitingQueue.GetCount()}\n");
	}
	public int GetRoundaboutVehicleCount()
	{
		return roundabout.GetCount();
	}

	public int GetQueueVehicleCount()
	{
		return waitingQueue.GetCount();
	}
}
