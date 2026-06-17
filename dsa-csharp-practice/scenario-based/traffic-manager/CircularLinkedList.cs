using System;
using System.Collections.Generic;
public class CircularLinkedList
{
	private Vehicle head;
	private Vehicle tail;
	private int count;

	public CircularLinkedList()
	{
		head=null;
		tail=null;
		count=0;
	}
	public int GetCount()
	{
		return count;
	}

	public void AddVehicle(Vehicle vehicle)
	{
		if(vehicle==null)
		{
			Console.WriteLine("can't add null vehicle");
			return;
		}
		if(head==null)
		{
			head=vehicle;
			tail=vehicle;
			head.Next=head;
			count++;
			Console.WriteLine($"first vehicle {vehicle.VehicleNumber} added to roundabout");
		}
		else
		{
			tail.Next=vehicle;
			vehicle.Next=head;
			tail=vehicle;
			count++;
			Console.WriteLine($"vehicle {vehicle.VehicleNumber} added to roundabout");
		}
	}

	public Vehicle RemoveVehicle()
	{
		if(head==null)
		{
			Console.WriteLine("list is already empty,can't remove this vehicle");
			return null;
		}
		Vehicle removed=head;
		if(head==tail)
		{
			head=null;
			tail=null;
			count--;
			Console.WriteLine($"vehicle {removed.VehicleNumber} has been removed from the list and list is now empty.");
			return removed;
		}

		head=head.Next;
		tail.Next=head;
		count--;
		Console.WriteLine($"vehicle {removed.VehicleNumber} has been removed from the list");
		return removed;
	}

	public void DisplayRoundabout()
	{
		if(head==null)
		{
			Console.WriteLine("list is empty");
			return;
		}

		Console.WriteLine("roundabaout status:");
		Console.WriteLine($"total number of vehicles in roundabout is {count}");
		Console.WriteLine("vehicles in circular path: ");

		Vehicle current=head;
		int position=1;
		do
		{
			Console.Write($"Position {position}: ");
			current.DisplayInfo();
			current=current.Next;
			position++;
		} while(current!=head);

		Console.WriteLine(" ");
	}
	public bool IsEmpty()
	{
		return head==null;
	}
}
