using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Student
{
    public string name;
    public int age;
    public List<string> subjects;
}

class Program
{
    static void Main()
    {
        Student s = new Student
        {
            name = "Ojas",
            age = 21,
            subjects = new List<string> { "Math", "Science" }
        };

        string json = JsonConvert.SerializeObject(s, Formatting.Indented);
        Console.WriteLine(json);
    }
}
