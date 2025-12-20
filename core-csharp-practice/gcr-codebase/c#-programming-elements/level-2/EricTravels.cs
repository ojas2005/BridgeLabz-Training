using System;

class TravelComputation {
   public static void Main(string[] args) {

      // Create a variable 'name' to indicate the person traveling
      string name = Console.ReadLine();
      
      // Create variables 'fromCity', 'viaCity', and 'toCity' for the cities
      string fromCity = Console.ReadLine(), viaCity = Console.ReadLine(), toCity =Console.ReadLine();

      // Create variables for distances and times
      double distanceFromToVia = double.Parse(Console.ReadLine());
      int timeFromToVia = int.Parse(Console.ReadLine());
      double distanceViaToFinalCity = double.Parse(Console.ReadLine());
      int timeViaToFinalCity = int.Parse(Console.ReadLine()); 

      // Compute the total distance and total time
      double totalDistance = distanceFromToVia + distanceViaToFinalCity;
      int totalTime = timeFromToVia + timeViaToFinalCity*60; //converting time in hours to time in minutes.

      // Print the travel details
      Console.WriteLine($"The Total Distance travelled by {name} from {fromCity} to {toCity} via {viaCity} is {totalDistance} km and the Total Time taken is {totalTime} minutes");
   }
}
