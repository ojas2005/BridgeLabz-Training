using System;
class Operators{
    static void Main()
    {
        int a = 10; //operand 1
        int b = 32; //operand 2

        //***Arithmetic Operators***
        int sum = a+b; //Calculates the sum of the two operands.
        Console.WriteLine(sum);

        int sub = a-b; //Calculates the difference between the two operands.
        Console.WriteLine(sub);

        int mul = a*b; //Performs the multiplication operation on the two operands.
        Console.WriteLine(mul);

        float div = a/b; //Performs the division operation on the two operands.
        Console.WriteLine(div);
         
        int mod = a%b; //Performs modulus operation on the two operands.
        Console.WriteLine(mod);

        //***Relational Operators***
        Console.WriteLine(a==b); //Checks if a and b are equal.
        Console.WriteLine(a!=b); //Checks if a and b are not equal.
        Console.WriteLine(a>b); //Checks if a is greater than b.
        Console.WriteLine(a<b); //Checks if a is lesser than b.
        Console.WriteLine(a>=b); //Checks if a is greater than or equals to b.
        Console.WriteLine(a<=b); //Checks if a is lesser than or equals to b.
        
        //***Logical Operators***
        bool x = true;
        bool y = false;
        Console.WriteLine(x && y); //Checks if x and y both are true or not, Output = False.
        Console.WriteLine(x || y); //Checks if any one of the two operands is true. output = true.
        Console.WriteLine(!x); //Reverses the logical state of its operand.Output = Flase;
        
        //***Assignment operators***
        int val = 100; //Assigned the value 100 to the variable var.
        val += 5; //Adds 5 in val,now val = 105.
        val-= 5; //Subtracts 5 from val,now val = 100.
        val *= 2; //Multiplies val with 2 now val = 200.
        val /= 4; //Divides val by 4 now val = 50.
        val %= 10; //Takes the modulus using two operands and assigns the result. val = 0.

        //***Unary Operators***

        int num = (+100); //unary plus 
        int neg = (-20); //unary minus

        num++; //increments the value of num by 1.
        Console.WriteLine(num); //Output = 101.

        num--; //Decrements the value of num by 1.
        Console.WriteLine(num); //Output = 100.

        bool isTrue = true;
        Console.WriteLine(!isTrue); //Negates the value of binary operands.

        //***Ternary Operator***.

        Console.WriteLine((a>b)?a:b); //If a is greater than b then it will output a,otherwise b.

        //***is operator***

        Console.WriteLine(a is int); //Outputs true,Checks if the variable is of that data type.
        }
}