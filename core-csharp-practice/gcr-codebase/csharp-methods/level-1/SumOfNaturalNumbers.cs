using System;
class SumOfNaturalNumbers{
    public static int Sum(int number){

       
        //calculating sum of n natural numbers.
        int sum = (number*(number+1))/2;

        //returning the results.
        return sum;
        
    
}

    static void Main()
{
    //taking number as input.
    int number = int.Parse(Console.ReadLine());
     //checking if number is a natural number(including zero).
    if(number>=0){
    int result = Sum(number);
    Console.WriteLine($"The sum of {number} natural numbers is {result}");
    }
    else{
        Console.WriteLine("The number is not a natural number");
    }

    


}
}