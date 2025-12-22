/* Create a variable total of type double initialize to 0.0. Also, create a variable to store the double value the user enters
Use the while loop to check if the user entered is 0
If the user entered value is not 0 then inside the while block add user entered value to the total and ask the user to input again
The loop will continue till the user enters zero and outside the loop display the total value
*/

using System;
class SumTillPositive{
    static void Main()
    {
        //taking number as input and setting total to zero;
        double total=0;
        double number = double.Parse(Console.ReadLine());

        //while loop which runs till number is greater than 0.
        while(number>0)
        {
            total+=number;
            double num = double.Parse(Console.ReadLine());
            number = num;

        }
        Console.WriteLine($"{total}");
    }
}