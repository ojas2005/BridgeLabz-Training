using System;
    class PalindromeStringCheck{

        static void isPalindrome(string str)
        {
            string result = "";
            for(int i=str.Length-1;i>=0;i--)
            {
                result+=str[i];
            }
            if(result==str)
            {
                Console.WriteLine("Palindrome");
            }
            else{
                Console.WriteLine("not palindrome");
            }
        }
        static void Main(){
            string str = Console.ReadLine();
            isPalindrome(str);

        }
    }
