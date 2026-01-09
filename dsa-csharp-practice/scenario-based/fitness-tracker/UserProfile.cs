namespace FitTracker
{
  public class UserProfile
  {
    public string name;
    public int age;
    public double weight;
    public List<Workout> workouts;

    public UserProfile(string name, int age, double weight)
    {
      this.name=name;
      this.age=age;
      this.weight=weight;
      this.workouts=new List<Workout>();
    }
  }
}
