using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Main()
    {
        string json = @"[
          {'name':'A','age':20},
          {'name':'B','age':30}
        ]";

        JArray arr = JArray.Parse(json);

        foreach (var item in arr)
        {
            if ((int)item["age"] > 25)
                Console.WriteLine(item["name"]);
        }
    }
}
