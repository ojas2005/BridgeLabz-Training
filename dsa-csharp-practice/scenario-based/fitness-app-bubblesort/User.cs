public class User:IUser
{
    private string name;
    private int steps;
    public User(string name,int steps)
    {
        this.name=name;
        this.steps=steps;
    }
    public string GetName()
    {
        return name;
    }
    public int GetSteps()
    {
        return steps;
    }

    public void AddSteps(int s)
    {
        steps=steps+s;
    }
}