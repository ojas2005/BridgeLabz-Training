using System;

class ParagraphFormatter
{
    static void Main(string[] args)
    {
        string inputPara=Console.ReadLine();
        Formatter(inputPara);
        Console.WriteLine(WordCount(inputPara));
        Console.WriteLine(LongestWord(inputPara));
        Console.WriteLine(ReplaceWord(inputPara,"hi","hello"));
    }
    private static void Formatter(string inputPara)
    {
        while(true)
        {
            Console.WriteLine("-----------------------------------Menu----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1.Spaces after punctuation");
            Console.WriteLine("2.Capital letter after period");
            Console.WriteLine("3.Trim extra spaces");
            Console.WriteLine("4.Exit");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("");

            int selectedOption=int.Parse(Console.ReadLine());
            if(selectedOption==4)
                break;

            switch(selectedOption)
            {
                case 1:
                    for(int i=0;i<inputPara.Length-1;i++)
                    {
                        if(".,?!:-".Contains(inputPara[i])&&inputPara[i+1]!=' ')
                        {
                            inputPara=inputPara.Insert(i+1," ");
                        }
                    }
                    Console.WriteLine(inputPara);
                    break;
                case 2:
                    for(int i=0;i<inputPara.Length-1;i++)
                    {
                        if(inputPara[i]=='.'||inputPara[i]=='?'||inputPara[i]=='!')
                        {
                            int j=i+1;
                            while(j<inputPara.Length&&inputPara[j]==' ')
                                j++;

                            if(j<inputPara.Length)
                                inputPara=inputPara.Substring(0,j)+char.ToUpper(inputPara[j])+inputPara.Substring(j+1);
                        }
                    }
                    Console.WriteLine(inputPara);
                    break;

                case 3:
                string result="";
                bool space=false;

                for(int i=0;i<inputPara.Length;i++)
                {
                    if(inputPara[i]!=' ')
                    {
                        result+=inputPara[i];
                        space=false;
                    }
                    else if(!space)
                    {
                        result+=' ';
                        space=true;
                    }
                }

                inputPara=result.Trim();
                Console.WriteLine(inputPara);
                break;


                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
    private static int WordCount(string inputPara)
    {
        int count=0;
        bool word=false;

        for(int i=0;i<inputPara.Length;i++)
        {
            if(inputPara[i]!=' '&&!word)
            {
                count++;
                word=true;
            }
            else if(inputPara[i]==' ')
            {
                word=false;
            }
        }
        return count;
    }

    private static string LongestWord(string inputPara)
    {
        string word="";
        string longest="";

        for(int i=0;i<inputPara.Length;i++)
        {
            if(inputPara[i]==' ')
            {
                if(word.Length>longest.Length)
                    longest=word;
                word="";
            }
            else
            {
                word+=inputPara[i];
            }
        }

        if(word.Length>longest.Length)
            longest=word;

        return longest;
    }
    private static string ReplaceWord(string s,string o,string n)
    {
        string r="";
        int i=0;

        while(i<s.Length)
        {
            if(i+o.Length<=s.Length&&s.Substring(i,o.Length)==o)
            {
                r+=n;
                i+=o.Length;
            }
            else
            {
                r+=s[i];
                i++;
            }
        }
        return r;
    }
}
