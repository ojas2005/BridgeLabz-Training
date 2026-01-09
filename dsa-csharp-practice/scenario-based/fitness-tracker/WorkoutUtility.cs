namespace FitTracker
{
  public class WorkoutUtility
  {
    public static void AddWorkout(UserProfile user, Workout workout)
    {
      user.workouts.Add(workout);
      Console.WriteLine("details saved.");
    }
    public static void DisplayAllWorkouts(UserProfile user)
    {
      if(user.workouts.Count==0)
      {
        Console.WriteLine("cannot find any previos workout");
        return;
      }
      Console.WriteLine($"\nworkouts for {user.name} ");
      for(int i=0; i<user.workouts.Count; i++)
      {
        Console.WriteLine("\nWorkout "+(i+1)+":");
        user.workouts[i].Display();
      }
    }
    public static void DisplayUserProfile(UserProfile user)
    {
      Console.WriteLine($"User Profile ");
      Console.WriteLine($"name:- {user.name}");
      Console.WriteLine($"age:- {user.age}");
      Console.WriteLine($"weight:- {user.weight} kg");
      Console.WriteLine($"total Workouts:- {user.workouts.Count}");
    }

    public static int GetTotalCalories(UserProfile user)
    {
      int total=0;
      for(int i=0; i<user.workouts.Count; i++)
      {
        total=total+user.workouts[i].calories;
      }
      return total;
    }
    public static void DisplayCalorieSummary(UserProfile user)
    {
      int total=GetTotalCalories(user);
      Console.WriteLine($"total calories burned:{total}");
    }
  }
}
