using System;

class NumberCheckerII
{
    // method to count digits
    public static int CountDigits(int number)
    {
        int count = 0;
        int temp = number;

        while (temp > 0)
        {
            count++;
            temp /= 10;
        }
        return count;
    }

    // method to store digits in array
    public static int[] StoreDigits(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];

        int temp = number;
        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }
        return digits;
    }

    // method to find sum of digits
    public static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            sum += digits[i];
        }
        return sum;
    }

    // method to find sum of squares of digits
    public static int SumOfSquares(int[] digits)
    {
        int sum = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            sum += (int)Math.Pow(digits[i], 2);
        }
        return sum;
    }

    // method to check Harshad number
    public static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return number % sum == 0;
    }

    // method to find frequency of each digit
    public static int[,] DigitFrequency(int[] digits)
    {
        int[,] freq = new int[10, 2];

        // initialize digit column
        for (int i = 0; i < 10; i++)
        {
            freq[i, 0] = i;
            freq[i, 1] = 0;
        }

        // count frequency
        for (int i = 0; i < digits.Length; i++)
        {
            freq[digits[i], 1]++;
        }

        return freq;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int[] digits = StoreDigits(number);

        Console.WriteLine("\nDigits of number:");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i] + " ");
        }

        Console.WriteLine("\n\nCount of digits: " + CountDigits(number));
        Console.WriteLine("Sum of digits: " + SumOfDigits(digits));
        Console.WriteLine("Sum of squares of digits: " + SumOfSquares(digits));
        Console.WriteLine("Harshad Number: " + IsHarshadNumber(number, digits));

        int[,] frequency = DigitFrequency(digits);

        Console.WriteLine("\nDigit Frequency:");
        Console.WriteLine("Digit\tFrequency");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i, 1] > 0)
            {
                Console.WriteLine(frequency[i, 0] + "\t" + frequency[i, 1]);
            }
        }
    }
}
