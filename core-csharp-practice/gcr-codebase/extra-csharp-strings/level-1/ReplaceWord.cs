using System;
class ReplaceWord
{
     static void Main()
    {
        string str = Console.ReadLine();
        string wordToReplace = Console.ReadLine();
        string replaceWith = Console.ReadLine();
        string result = str.Replace(wordToReplace, replaceWith);
        Console.WriteLine(result);
    }
}
