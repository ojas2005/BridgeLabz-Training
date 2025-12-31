using System;

class VowelConsonantCount
{
   static void Main()
    {
        string str=Console.ReadLine().ToLower(); //a and A both are vowels so taking lowecase for ease.
        int vow = 0,cons=0; //counter for vowels and consonants
        for (int i=0;i<str.Length;i++)
        {
            if (str[i]>='a'&&str[i]<='z') //only checks for english alphabets
            {
                if ("aeiou".Contains(str[i])) //to check vowels
                    vow++;
                else //to check consonants
                    cons++;
            }
        }
        Console.WriteLine("total number of vowels is" + vow);
        Console.WriteLine("total number of consonants is " + cons);
    }
}
