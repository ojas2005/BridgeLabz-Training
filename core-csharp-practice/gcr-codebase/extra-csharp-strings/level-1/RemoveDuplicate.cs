using System;
class RemoveDuplicates
{
    static void Main()
    {
        string str = Console.ReadLine();
        string result = "";
        for(int i=0;i<str.Length;i++)
        {
            if(result.Contains(str[i])==false)
                result+=str[i];
        }
        Console.WriteLine(result);
    }
}
