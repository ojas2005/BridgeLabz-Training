using Newtonsoft.Json.Linq;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        JObject obj = JObject.Parse(File.ReadAllText("data.json"));

        foreach (var p in obj)
            Console.WriteLine(p.Key + " : " + p.Value);
    }
}
