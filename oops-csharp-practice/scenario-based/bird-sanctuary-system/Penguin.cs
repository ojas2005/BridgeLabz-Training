class Penguin:Bird,ISwimmable
{
    public Penguin(string n,string c,int a):
    base(n,c,a,"icy place"){}
    public void Swim(){
        Console.WriteLine($"{name} is swimming");
    }
    public override void Eat(){
        Console.WriteLine($"{name} is eating fish");
    }
}