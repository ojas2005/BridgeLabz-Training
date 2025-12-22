/* Create a variable total of type double initialize to 0.0. Also, create a variable to store the double value the user enters
Use the while loop to check if the user entered is 0
If the user entered value is not 0 then inside the while block add user entered value to the total and ask the user to input again
The loop will continue till the user enters zero and outside the loop display the total value
*/

using System;
class SumTillZero{
    static void Main()
    {
        //taking number as input and setting total to zero;
        double total=0;
        double number = double.Parse(Console.ReadLine());
        while(number!=0) //while loop which runs till number is not equals to zero.
        {
            total+=number; //adding value of numbers to total.
            double num = double.Parse(Console.ReadLine()); //taking new input for next value.
            number = num; //setting this new value to numbers variable to check if its 0 or not.

        }
        //printing total
        Console.WriteLine($"{total}");
    }
}