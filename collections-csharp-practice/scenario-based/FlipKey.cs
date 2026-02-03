using System;
using System.Text.RegularExpressions;
public class FlipKey
{
    public static string GenerateKey(string input)
    {
        if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^[A-Za-z]{6,}$"))
        {
            return "";
        }
        input=input.ToLower();

        string filtered="";
        foreach(char c in input)
        {
            if ((int)c%2!=0)
            {
                filtered+=c;
            }
        }
        char[] arr=filtered.ToCharArray();
        Array.Reverse(arr);
        for(int i=0;i<arr.Length;i++)
        {
            if (i%2==0)
            {
                arr[i]=char.ToUpper(arr[i]);
            }
        }
        return new string(arr);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("enter the word");
        string input=Console.ReadLine();

        string result=GenerateKey(input);

        if (result=="")
        {
            Console.WriteLine("enter a valid input");
        }
        else
        {
            Console.WriteLine("the new encrypted key is:- " + result);
        }
    }
}
