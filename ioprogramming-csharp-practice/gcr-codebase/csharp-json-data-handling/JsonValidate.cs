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
            'email':{'type':'string'}
          },
          'required':['email']
        }";

        JSchema schema = JSchema.Parse(schemaData);
        JObject obj = JObject.Parse(@"{ 'email':'test@mail.com' }");

        bool valid = obj.IsValid(schema);
        Console.WriteLine(valid);
    }
}
