using System;
class ReturnAllCharacters{

    public static char[] CharacterReturn(string string1)
    {
        char[] character = new char[string1.Length];
        int n = string1.Length;
        for(int i=0;i<n;i++)
        {
            character[i] = string1[i];
        }
        return character;
    }
    static void Main()
    {
        string string1 = Console.ReadLine();
        char[] result = CharacterReturn(string1);
        char[] resultUsingToCharArray = string1.ToCharArray();
        foreach(char i in result)
        {
            Console.Write(i +" "); //without using built in function
        }
        Console.WriteLine("");
        foreach(char i in resultUsingToCharArray)
        {
            Console.Write(i +" "); // using built in function
        }

    }
}