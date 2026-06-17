using Newtonsoft.Json;
using System;
using System.Xml;

class Program
{
    static void Main()
    {
        string json = @"{ 'name':'Ojas','age':22 }";
        XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "Root");
        Console.WriteLine(doc.OuterXml);
    }
}
