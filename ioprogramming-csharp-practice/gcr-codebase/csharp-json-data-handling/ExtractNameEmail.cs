using Newtonsoft.Json.Linq;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string data = File.ReadAllText("user.json");
        JObject obj = JObject.Parse(data);
        Console.WriteLine(obj["name"]);
        Console.WriteLine(obj["email"]);
    }
}
