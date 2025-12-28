using System;
class CompareStrings{
    public static bool StringComparison(string string1, string string2)
    {
        if (string1.Length != string2.Length)
        {
            return false;
        }
        for (int i = 0;i<string1.Length;i++)
        {
            if(string1[i]!=string2[i])
            {
                return false;
            }
        }
        return true;
        }
    static void Main(){
        string string1 = Console.ReadLine();
        string string2 = Console.ReadLine();
        bool result = StringComparison(string1,string2);
        bool resultUsingEquals = string1.Equals(string2);
        Console.WriteLine($"Are the two strings equal using CharAt logic? {result}");
        Console.WriteLine($"Are the two strings equal using Equals logic? {resultUsingEquals}");

    }



}