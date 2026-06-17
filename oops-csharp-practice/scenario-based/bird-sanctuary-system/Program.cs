using System;
class Program
{
    static Bird[] birds=new Bird[100]; //array to store birds
    static int count=0; //number of birds stored
    static string userName="";
    static void Main(){Login();}
    static void Login()
    {
        Console.Clear();
        Console.WriteLine("enter username:");
        string u=Console.ReadLine();
        Console.WriteLine("enter password:");
        string p=Console.ReadLine();
        if((u=="ojas"&&p=="1234"))
        {
            userName=u;
            Menu(); //calling menu function after successful login
        }
        else
        {
            Console.WriteLine("login failed"); 
            Login(); //using recursion logic if login fails
        }
    }
    static void Menu() //creating menu method
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {userName}");
            Console.WriteLine("Enter the operation you want to perform");
            Console.WriteLine("Press 1 to Add Bird");
            Console.WriteLine("Press 2 to view Birds");
            Console.WriteLine("Press 3 for Fly Action");
            Console.WriteLine("Press 4 for Swim Action");
            Console.WriteLine("Press 5 for All Actions");
            Console.WriteLine("Press 6 to Exit");
            string choice=Console.ReadLine();
            switch(choice)
            {
                case "1":
                    AddBird();
                    break;
                case "2":
                    ViewBirds();
                    break;
                case "3":
                    ShowFly();
                    break;
                case "4":
                    ShowSwim();
                    break;
                case "5":
                    ShowAll();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("please enter a valid input");
                    break;
            }
            Console.WriteLine("press any key to restart the menu");
            Console.ReadKey();
        }
    }
    //defining methods which are present in our menu
    static void AddBird()
    {
        Console.Clear();
        Console.WriteLine("Which bird do you want to add?");
        Console.WriteLine("Press 1 to add Eagle");
        Console.WriteLine("Press 2 to add Sparrow");
        Console.WriteLine("Press 3 to add Duck");
        Console.WriteLine("Press 4 to add Penguin");
        Console.WriteLine("Press 5 to add Seagull");
        string type=Console.ReadLine();

        switch(type)
        {
            case "1":
            {
                Console.WriteLine("Enter name of the bird- ");
                string n=Console.ReadLine();
                Console.WriteLine("Enter color of the bird- ");
                string c=Console.ReadLine();
                Console.WriteLine("Enter age of the bird- ");
                int a=int.Parse(Console.ReadLine());
                birds[count]=new Eagle(n,c,a);
                count++;
                Console.WriteLine("Eagle added");
                break;
            }
            case "2":
            {
                Console.WriteLine("Enter name of the bird- ");
                string n=Console.ReadLine();
                Console.WriteLine("Enter color of the bird- ");
                string c=Console.ReadLine();
                Console.WriteLine("Enter age of the bird- ");
                int a=int.Parse(Console.ReadLine());
                birds[count]=new Sparrow(n,c,a);
                count++;
                Console.WriteLine("Sparrow added");
                break;
            }
            case "3":
            {
                Console.WriteLine("Enter name of the bird- ");
                string n=Console.ReadLine();
                Console.WriteLine("Enter color of the bird- ");
                string c=Console.ReadLine();
                Console.WriteLine("Enter age of the bird- ");
                int a=int.Parse(Console.ReadLine());                
                birds[count]=new Duck(n,c,a);
                count++;
                Console.WriteLine("Duck added");
                break;
            }
            case "4":
            {
                Console.WriteLine("Enter name of the bird- ");
                string n=Console.ReadLine();
                Console.WriteLine("Enter color of the bird- ");
                string c=Console.ReadLine();
                Console.WriteLine("Enter age of the bird- ");
                int a=int.Parse(Console.ReadLine());                
                birds[count]=new Penguin(n,c,a);
                count++;
                Console.WriteLine("Penguin added");
                break;
            }
            case "5":
            {
                Console.WriteLine("Enter name of the bird- ");
                string n=Console.ReadLine();
                Console.WriteLine("Enter color of the bird- ");
                string c=Console.ReadLine();
                Console.WriteLine("Enter age of the bird- ");
                int a=int.Parse(Console.ReadLine());                
                birds[count]=new Seagull(n,c,a);
                count++;
                Console.WriteLine("Seagull added");
                break;
            }
            default:
            {
                Console.WriteLine("enter a valid choice");
                break;
            }
        }
    }
    static void ViewBirds()
    {
        Console.Clear();
        if(count==0){
            Console.WriteLine("No birds");
            return;
        }
        for(int i=0;i<count;i++){
            birds[i].Info();
        }
    }
    static void ShowFly()
    {
        Console.Clear();
        bool found=false;
        for(int i=0;i<count;i++)
        {
            if(birds[i] is IFlyable f) //if our bird is fylable then value of birds[i] will automatically get assigned to f.
            {
                birds[i].Info(); //printing bird information
                f.Fly();
                found=true;
            }
        }
        if(found==false){
        Console.WriteLine("No flying birds");
        }
    }
    static void ShowSwim()
    {
        Console.Clear();
        bool found=false;
        for(int i=0;i<count;i++)
        {
            if(birds[i] is ISwimmable s)//if our bird is swimmable then value of birds[i] will automatically get assigned to s.
            {
                birds[i].Info();
                s.Swim();
                found=true;
            }
        }
        if(found==false){
        Console.WriteLine("No swimming birds"); //if there are no swimmable birds.
        }
    }
    static void ShowAll()
    {
        Console.Clear();
        if(count==0){
            Console.WriteLine("No birds"); //if no birds have been added
            return;
        } 
        for(int i=0;i<count;i++)
        {
            Console.WriteLine($"{birds[i].name}");
            birds[i].Eat();
            birds[i].Rest();
            if(birds[i] is IFlyable f){ 
                f.Fly();
            }
            if(birds[i] is ISwimmable s) {
                s.Swim();
            }
        }
    }
}
