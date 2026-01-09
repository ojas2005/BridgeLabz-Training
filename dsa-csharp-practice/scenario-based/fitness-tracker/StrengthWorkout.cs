namespace FitTracker
{
  public class StrengthWorkout: Workout
  {
    public string exercise;
    public int sets;
    public int reps;
    public StrengthWorkout(string type, int duration, int calories, string date, string exercise, int sets, int reps)
      : base(type, duration, calories, date)
    {
      this.exercise=exercise;
      this.sets=sets;
      this.reps=reps;
    }
    public override void Track()
    {
      Console.WriteLine($"tracking strength workout: {exercise}");
    }
    public override void Display()
    {
        Console.WriteLine($"type:- {type}");
        Console.WriteLine($"exercise:- {exercise}");
        Console.WriteLine($"sets:- {sets}");
        Console.WriteLine($"reps:- {reps}");
        Console.WriteLine($"duration:- {duration} minutes");
        Console.WriteLine($"calories:- {calories}");
        Console.WriteLine($"date:- {date}");
    }

  }
}
