using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("pipe cutting revenue optimizer");
        Console.WriteLine();

        Controller controller=new Controller();
        controller.executeA();
        controller.executeB();
        controller.executeC();
        Console.WriteLine("execution completed");
        Console.ReadKey();
    }
}
