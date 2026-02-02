using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Main()
    {
        JObject a = JObject.Parse(@"{ 'name':'Ojas' }");
        JObject b = JObject.Parse(@"{ 'age':22 }");
        a.Merge(b);
        Console.WriteLine(a.ToString());
    }
}
