using System;
interface IFlyable
{
    void Fly();
}
interface ISwimmable
{
    void Swim();
}
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
        Console.WriteLine($"Name:{name},Color:{color},Age:{age},Place:{place}");
    }
}
class Eagle:Bird,IFlyable
{
    public Eagle(string n,string c,int a):base(n,c,a,"Hills"){}
    public void Fly(){Console.WriteLine($"{name} flies high");}
    public override void Eat(){Console.WriteLine($"{name} eats meat");}
}
class Sparrow:Bird,IFlyable
{
    public Sparrow(string n,string c,int a):base(n,c,a,"Trees"){}
    public void Fly(){Console.WriteLine($"{name} flies fast");}
    public override void Eat(){Console.WriteLine($"{name} eats grains");}
}
class Duck:Bird,ISwimmable
{
    public Duck(string n,string c,int a):base(n,c,a,"Lake"){}
    public void Swim(){Console.WriteLine($"{name} swims slow");}
    public override void Eat(){Console.WriteLine($"{name} eats plants");}
}
class Penguin:Bird,ISwimmable
{
    public Penguin(string n,string c,int a):base(n,c,a,"Ice land"){}
    public void Swim(){Console.WriteLine($"{name} swims fast");}
    public override void Eat(){Console.WriteLine($"{name} eats fish");}
}
class Seagull:Bird,IFlyable,ISwimmable
{
    public Seagull(string n,string c,int a):base(n,c,a,"Sea side"){}
    public void Fly(){Console.WriteLine($"{name} flies near sea");}
    public void Swim(){Console.WriteLine($"{name} swims in sea");}
    public override void Eat(){Console.WriteLine($"{name} eats leftovers");}
}
class Program
{
    static Bird[] birds=new Bird[100]; // array to store birds
    static int count=0; // number of birds stored
    static string userName="";
    static void Main(){Login();}
    static void Login()
    {
        Console.Clear();
        Console.WriteLine("Enter username:");
        string u=Console.ReadLine();
        Console.WriteLine("Enter password:");
        string p=Console.ReadLine();

        if((u=="admin"&&p=="123")||(u=="staff"&&p=="456"))
        {
            userName=u;
            Menu();
        }
        else
        {
            Console.WriteLine("Login failed");
            System.Threading.Thread.Sleep(1500);
            Login();
        }
    }
    static void Menu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {userName}");
            Console.WriteLine("1.Add Bird");
            Console.WriteLine("2.View Birds");
            Console.WriteLine("3.Fly Action");
            Console.WriteLine("4.Swim Action");
            Console.WriteLine("5.All Actions");
            Console.WriteLine("6.Exit");

            string ch=Console.ReadLine();
            switch(ch)
            {
                case "1":AddBird();break;
                case "2":ViewBirds();break;
                case "3":ShowFly();break;
                case "4":ShowSwim();break;
                case "5":ShowAll();break;
                case "6":return;
                default:Console.WriteLine("Wrong input");break;
            }
            Console.WriteLine("Press key");
            Console.ReadKey();
        }
    }
    static void AddBird()
    {
        Console.Clear();
        Console.WriteLine("1.Eagle\n2.Sparrow\n3.Duck\n4.Penguin\n5.Seagull");
        string type=Console.ReadLine();
        Console.WriteLine("Enter name:"); string n=Console.ReadLine();
        Console.WriteLine("Enter color:"); string c=Console.ReadLine();
        Console.WriteLine("Enter age:"); int a=int.Parse(Console.ReadLine());
        switch(type)
        {
            case "1":birds[count]=new Eagle(n,c,a);break;
            case "2":birds[count]=new Sparrow(n,c,a);break;
            case "3":birds[count]=new Duck(n,c,a);break;
            case "4":birds[count]=new Penguin(n,c,a);break;
            case "5":birds[count]=new Seagull(n,c,a);break;
            default:Console.WriteLine("Wrong type");return;
        }
        count++;
        Console.WriteLine("Bird added");
    }
    static void ViewBirds()
    {
        Console.Clear();
        if(count==0){Console.WriteLine("No birds");return;}
        for(int i=0;i<count;i++){birds[i].Info();}
    }
    static void ShowFly()
    {
        Console.Clear();
        bool found=false;
        for(int i=0;i<count;i++)
        {
            if(birds[i] is IFlyable f)
            {
                birds[i].Info();
                f.Fly();
                found=true;
            }
        }
        if(!found)Console.WriteLine("No flying birds");
    }
    static void ShowSwim()
    {
        Console.Clear();
        bool found=false;
        for(int i=0;i<count;i++)
        {
            if(birds[i] is ISwimmable s)
            {
                birds[i].Info();
                s.Swim();
                found=true;
            }
        }
        if(!found)Console.WriteLine("No swimming birds");
    }
    static void ShowAll()
    {
        Console.Clear();
        if(count==0){Console.WriteLine("No birds");return;}
        for(int i=0;i<count;i++)
        {
            Console.WriteLine($"{birds[i].name}");
            birds[i].Eat();
            birds[i].Rest();
            if(birds[i] is IFlyable f) f.Fly();
            if(birds[i] is ISwimmable s) s.Swim();
        }
    }
}
