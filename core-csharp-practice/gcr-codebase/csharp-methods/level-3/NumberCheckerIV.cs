using System;

class NumberCheckerIV
{
    // method to check prime number
    public static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // method to check neon number
    // neon number: sum of digits of square == number
    public static bool IsNeonNumber(int number)
    {
        int square = number * number;
        int sum = 0;

        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }

        return sum == number;
    }

    // method to check spy number
    // sum of digits == product of digits
    public static bool IsSpyNumber(int number)
    {
        int sum = 0;
        int product = 1;
        int temp = number;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += digit;
            product *= digit;
            temp /= 10;
        }

        return sum == product;
    }

    // method to check automorphic number
    // square ends with the number itself
    public static bool IsAutomorphic(int number)
    {
        int square = number * number;
        string numStr = number.ToString();
        string squareStr = square.ToString();

        return squareStr.EndsWith(numStr);
    }

    // method to check buzz number
    // divisible by 7 or ends with 7
    public static bool IsBuzzNumber(int number)
    {
        return (number % 7 == 0) || (number % 10 == 7);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("\nResults:");
        Console.WriteLine("Prime Number: " + IsPrime(number));
        Console.WriteLine("Neon Number: " + IsNeonNumber(number));
        Console.WriteLine("Spy Number: " + IsSpyNumber(number));
        Console.WriteLine("Automorphic Number: " + IsAutomorphic(number));
        Console.WriteLine("Buzz Number: " + IsBuzzNumber(number));
    }
}
