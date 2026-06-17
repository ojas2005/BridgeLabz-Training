class Seagull:Bird,IFlyable,ISwimmable
{
    public Seagull(string n,string c,int a):
                    base(n,c,a,"Sea side"){}
    public void Fly(){
        Console.WriteLine($"{name} starts flying near sea");
    }
    public void Swim(){
        Console.WriteLine($"{name} starts swimming in the sea");
    }
    public override void Eat(){
        Console.WriteLine($"{name} starts eating");
    }
}