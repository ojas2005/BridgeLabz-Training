using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class User
{
    public string Name;
    public int Age;
}

class Program
{
    static void Main()
    {
        List<User> list = new List<User>
        {
            new User{Name="A",Age=20},
            new User{Name="B",Age=30}
        };

        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        Console.WriteLine(json);
    }
}
