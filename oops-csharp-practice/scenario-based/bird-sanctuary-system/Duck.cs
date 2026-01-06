class Duck:Bird,ISwimmable
{
    public Duck(string n,string c,int a):
                base(n,c,a,"Lake"){}
    public void Swim(){
        Console.WriteLine($"{name} swimming slowly");
    }
    public override void Eat(){
        Console.WriteLine($"{name} starts eating plants");
    }
}