class Eagle:Bird,IFlyable
{
    public Eagle(string n,string c,int a):
    base(n,c,a,"Hills"){}
    public void Fly(){
        Console.WriteLine($"{name} starts flying high");
    }
    public override void Eat(){
        Console.WriteLine($"{name} starts eating meat");
    }
}