using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("data.csv");
        var list = new List<Dictionary<string, string>>();

        var headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var dict = new Dictionary<string, string>();

            for (int j = 0; j < headers.Length; j++)
                dict[headers[j]] = values[j];

            list.Add(dict);
        }

        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        Console.WriteLine(json);
    }
}
