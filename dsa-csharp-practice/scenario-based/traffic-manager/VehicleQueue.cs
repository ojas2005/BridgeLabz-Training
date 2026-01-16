using System;

public class VehicleQueue
{
	private Vehicle[] queueArray;
	private int front;
	private int rear;
	private int count;
	private int maxSize;
	public VehicleQueue(int capacity)
	{
		maxSize=capacity;
		queueArray=new Vehicle[maxSize];
		front=0;
		rear=-1;
		count=0;
	}
	public int GetCount()
	{
		return count;
	}
	public bool IsEmpty()
	{
		return count==0;
	}
	public bool IsFull()
	{
		return count==maxSize;
	}
	public void Enqueue(Vehicle vehicle)
	{
		if(vehicle==null)
		{
			Console.WriteLine("can't enter null vehicle");
			return;
		}

		if(IsFull())
		{
			Console.WriteLine($"queue is full can't add vehicle number {vehicle.VehicleNumber})");
			return;
		}

		rear=(rear+1)%maxSize;
		queueArray[rear]=vehicle;
		count++;
		Console.WriteLine($"vehicle {vehicle.VehicleNumber} added to waiting queue. Queue size: {count}/{maxSize}");
	}

	public Vehicle Dequeue()
	{
		if(IsEmpty())
		{
			Console.WriteLine("no vehicles waiting to enter");
			return null;
		}

		Vehicle removed=queueArray[front];
		queueArray[front]=null;
		front=(front+1)%maxSize;
		count--;
		Console.WriteLine($"vehicle {removed.VehicleNumber} removed from waiting queue");
		return removed;
	}

	public Vehicle Peek()
	{
		if(IsEmpty())
		{
			Console.WriteLine("queue is empty");
			return null;
		}
		return queueArray[front];
	}
	public void DisplayQueue()
	{
		if(IsEmpty())
		{
			Console.WriteLine("waiting queue is empty");
			return;
		}

		Console.WriteLine("waiting queue: ");
		Console.WriteLine($"number of vehicles waiting to enter: {count}");
		Console.WriteLine("current queue: ");
		int index=front;
		int displayed=0;
		while(displayed<count)
		{
			Console.Write($"position {displayed+1}: ");
			queueArray[index].DisplayInfo();
			index=(index+1)%maxSize;
			displayed++;
		}

		Console.WriteLine("");
	}
}
