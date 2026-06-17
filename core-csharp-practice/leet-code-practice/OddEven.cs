using System;
class OddEven{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        if(n%2==0)
        {
            Console.WriteLine("Even");
        }
        else{
            Console.WriteLine("Odd");
        }
    }
}