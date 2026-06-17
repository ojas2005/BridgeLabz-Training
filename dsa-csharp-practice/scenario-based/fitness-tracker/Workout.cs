namespace FitTracker
{
  public abstract class Workout: ITrackable
  {
    public string type;
    public int duration;
    public int calories;
    public string date;

    public Workout(string type, int duration, int calories, string date)
    {
      this.type=type;
      this.duration=duration;
      this.calories=calories;
      this.date=date;
    }
    public abstract void Track();
    public abstract void Display();
  }
}
