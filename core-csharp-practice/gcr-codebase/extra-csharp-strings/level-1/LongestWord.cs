using System;
class LongestWord
{
static void Main()
    {
        string inputPara = Console.ReadLine();
        string word = "";
        string longest = "";

        for (int i = 0;i<inputPara.Length; i++)
        {
            if (inputPara[i] == ' ')
            {
                if (word.Length > longest.Length)
                    longest = word;
                word = "";
            }
            else
            {
                word += inputPara[i];
            }
        }

        if (word.Length > longest.Length)
            longest = word;

        Console.WriteLine(longest);
    }
}