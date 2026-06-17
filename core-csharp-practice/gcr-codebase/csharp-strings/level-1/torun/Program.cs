using System;
class ReverseAString{
    static void Main()
    {
        string str = Console.ReadLine();
        string result = "";
        for(int i=str.Length-1;i>=0;i++)
        {
            result = result+str[i];

}  
Console.WriteLine(result);
  }
}