using System;
class GcdAndLcm{
    static int Gcd(int num1,int num2)
    {
        while(num2!=0)
        {
        int rem = num1%num2;
        num1=num2;
        num2=rem;
        }
        return num1;
        
    }
    static int Lcm(int num1,int num2)
    {
        return (num1*num2)/(Gcd(num1,num2));
    }
    static void Main()
    {
        int num1=int.Parse(Console.ReadLine());
        int num2=int.Parse(Console.ReadLine());
        int gcd = Gcd(num1,num2);
        int lcm = Lcm(num1,num2);
        Console.WriteLine(gcd);
        Console.WriteLine(lcm);
    }
    
}