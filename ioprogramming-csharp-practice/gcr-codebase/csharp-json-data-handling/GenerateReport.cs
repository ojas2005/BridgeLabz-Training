using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Record
{
    public int Id;
    public string Name;
}

class Program
{
    static void Main()
    {
        List<Record> records = new List<Record>
        {
            new Record{Id=1,Name="A"},
            new Record{Id=2,Name="B"}
        };

        string report = JsonConvert.SerializeObject(records, Formatting.Indented);
        Console.WriteLine(report);
    }
}
