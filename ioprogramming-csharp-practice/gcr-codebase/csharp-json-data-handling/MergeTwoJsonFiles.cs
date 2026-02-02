using Newtonsoft.Json.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        JObject a = JObject.Parse(File.ReadAllText("a.json"));
        JObject b = JObject.Parse(File.ReadAllText("b.json"));
        a.Merge(b);
        File.WriteAllText("merged.json", a.ToString());
    }
}
