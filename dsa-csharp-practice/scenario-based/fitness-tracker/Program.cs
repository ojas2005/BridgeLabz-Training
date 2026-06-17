namespace FitTracker
{
  class Program
  {
    static void Main()
    {
      UserProfile user=new UserProfile("ramesh",27,56);
      bool running=true;
      while(running)
      {
        Menu.ShowMainMenu();
        string choice=Console.ReadLine();
        if(choice=="1")
        {
          Menu.AddCardioWorkoutMenu(user);
        }
        else if(choice=="2")
        {
          Menu.AddStrengthWorkoutMenu(user);
        }
        else if(choice=="3")
        {
          WorkoutUtility.DisplayAllWorkouts(user);
        }
        else if(choice=="4")
        {
          WorkoutUtility.DisplayUserProfile(user);
        }
        else if(choice=="5")
        {
          WorkoutUtility.DisplayCalorieSummary(user);
        }
        else if(choice=="6")
        {
          running=false;
        }
        else
        {
          Console.WriteLine("choose a valid option");
        }
      }
    }
  }
}
