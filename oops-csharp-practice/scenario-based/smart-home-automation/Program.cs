using System;
public class Program
{
    static void Main()
    {
        Light bedroom=new Light("Bedroom Light");
        Fan living= new Fan("Living Room Fan");
        AC kitchen= new AC("Kitchen AC");
        int choice;
        while (true)
        {
            Console.WriteLine("\nsmart home automation");
            Console.WriteLine("press 1 to turn on device");
            Console.WriteLine("press 2 to turn off device");
            Console.WriteLine("press 3 to control light");
            Console.WriteLine("press 4 to control fan");
            Console.WriteLine("press 5 to control ac");
            Console.WriteLine("press 6 to show status");
            Console.WriteLine("press 7 to exit");
            Console.Write("choose option: ");
            choice= int.Parse(Console.ReadLine());
            if (choice==1)
            {
                Console.WriteLine("press 1 for bedroom light");
                Console.WriteLine("press 2 for living room fan");
                Console.WriteLine("press 3 for kitchen ac");
                Console.Write("select device: ");
                int dev= int.Parse(Console.ReadLine());
                if (dev==1)
                {
                    bedroom.TurnOn();
                }
                else if (dev==2)
                {
                    living.TurnOn();
                }
                else if (dev==3)
                {
                    kitchen.TurnOn();
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==2)
            {
                Console.WriteLine("press 1 for bedroom light");
                Console.WriteLine("press 2 for living room fan");
                Console.WriteLine("press 3 for kitchen ac");
                Console.Write("select device: ");
                int dev= int.Parse(Console.ReadLine());
                if (dev==1)
                {
                    bedroom.TurnOff();
                }
                else if (dev==2)
                {
                    living.TurnOff();
                }
                else if (dev==3)
                {
                    kitchen.TurnOff();
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==3)
            {
                Console.Write("set brightness (0-100): ");
                int bright= int.Parse(Console.ReadLine());
                bedroom.SetBrightness(bright);
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==4)
            {
                Console.Write("set fan speed (0-100): ");
                int spd= int.Parse(Console.ReadLine());
                living.SetSpeed(spd);
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==5)
            {
                Console.WriteLine("press 1 to set temperature");
                Console.WriteLine("press 2 to set mode");
                Console.Write("choose option: ");

                int ac= int.Parse(Console.ReadLine());

                if (ac==1)
                {
                    Console.Write("enter temperature: ");
                    int temp= int.Parse(Console.ReadLine());
                    kitchen.SetTemperature(temp);
                }
                else if (ac==2)
                {
                    Console.Write("enter mode (cool/heat/dry): ");
                    string m= Console.ReadLine();
                    kitchen.SetMode(m);
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==6)
            {
                Console.WriteLine("\ndevice status:");
                Console.WriteLine("bedroom light: " + bedroom.GetStatus());
                Console.WriteLine("living room fan: " + living.GetStatus());
                Console.WriteLine("kitchen ac: " + kitchen.GetStatus());
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice==7)
            {
                break;
            }
        }
    }
}
