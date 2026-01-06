abstract class Bird
{
    public string name;
    public string color;
    public int age;
    public string place;
    public Bird(string n,string c,int a,string p)
    {
        name=n;
        color=c;
        age=a;
        place=p;
    }
    public virtual void Eat()
    {
        Console.WriteLine($"{name} is eating");
    }
    public virtual void Rest()
    {
        Console.WriteLine($"{name} is resting at {place}");
    }
    public void Info()
    {
        Console.WriteLine($"Name - {name},Color - {color},Age - {age},Place - {place}");
    }
}