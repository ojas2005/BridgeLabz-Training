using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

class Program
{
    static void Main()
    {
        string schemaData = @"{
          'type':'object',
          'properties':{
            'email':{'type':'string','format':'email'}
          }
        }";

        JSchema schema = JSchema.Parse(schemaData);
        JObject obj = JObject.Parse(@"{ 'email':'abc@mail.com' }");

        Console.WriteLine(obj.IsValid(schema));
    }
}
