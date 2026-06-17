using System;
using System.Text;
public class SB{
    public static StringBuilder WordInserting(StringBuilder word1, char ch, string word2)
    {
        for(int i=0;i<word1.Length;i++)
        {
            if(word1[i]==ch)
            {
                word1.Insert(i,word2);
            }
        }
        return word1;
    }

    static void Main()
    {
        string w1 = Console.ReadLine();
        char ch = char.Parse(Console.ReadLine());
        string w2 = Console.ReadLine();
        StringBuilder word1 = new StringBuilder(w1);
        word1 = WordInserting(word1,ch,w2);
        Console.WriteLine(word1.ToString());
        

    }
}