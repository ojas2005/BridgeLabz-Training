using System;
class BasicCalculator{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());

        //***Arithmetic Operators***
        int sum = number1+number2; //Calculates the sum of the two operands.
        

        int sub = number1-number2; //Calculates the difference between the two operands.
       

        int mul = number1*number2; //Performs the multiplication operation on the two operands.
        

        float div = (number1 *1f)/number2; //Performs the division operation on the two operands.
        
         

        Console.WriteLine($@"The addition, subtraction, multiplication and division value of 2 numbers {number1} and {number2} is {sum}, {sub}, {mul}, and {div}");


    }
}