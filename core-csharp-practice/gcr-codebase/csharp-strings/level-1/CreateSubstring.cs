using System;
class CreateSubstring{
    public static string SubstringUsingCharAt(string string1,int startIndex,int endIndex)
    {
        string temp = "";
        for(int i = startIndex;i<=endIndex;i++)
        {
            temp+=  string1[i];
        }
        return temp;
    }
    static void Main()
    {
        string string1 = Console.ReadLine();
        int startIndex = int.Parse(Console.ReadLine());
        int endIndex = int.Parse(Console.ReadLine());
        string result = SubstringUsingCharAt(string1,startIndex,endIndex);
        string resultUsingSubstring = string1.Substring(startIndex,endIndex-1);

        Console.WriteLine($"Substring using CharAt {result} ");
        Console.WriteLine($"Substring using Substring Built in method {resultUsingSubstring} ");
    }
}