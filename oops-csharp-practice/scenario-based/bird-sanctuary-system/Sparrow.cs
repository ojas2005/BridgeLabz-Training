class Sparrow:Bird,IFlyable
{
    public Sparrow(string n,string c,int a):base(n,c,a,"Trees"){}
    public void Fly(){
        Console.WriteLine($"{name} starts flying fast");
    }
    public override void Eat(){Console.WriteLine($"{name} starts eating food");}
}