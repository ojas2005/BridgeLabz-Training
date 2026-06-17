using System;

class NumberChecker
{
    // method to count digits in number
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

    // method to check duck number
    // duck number means number contains at least one non-zero digit
    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    // method to check armstrong number
    public static bool IsArmstrong(int number, int[] digits)
    {
        int power = digits.Length;
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            sum += (int)Math.Pow(digits[i], power);
        }

        return sum == number;
    }

    // method to find largest and second largest digit
    public static void FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }

        Console.WriteLine("Largest digit: " + largest);
        Console.WriteLine("Second largest digit: " + secondLargest);
    }

    // method to find smallest and second smallest digit
    public static void FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = digits[i];
            }
            else if (digits[i] < secondSmallest && digits[i] != smallest)
            {
                secondSmallest = digits[i];
            }
        }

        Console.WriteLine("Smallest digit: " + smallest);
        Console.WriteLine("Second smallest digit: " + secondSmallest);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int digitCount = CountDigits(number);
        int[] digits = StoreDigits(number);

        Console.WriteLine("\nNumber of digits: " + digitCount);

        Console.WriteLine("Digits are:");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i] + " ");
        }

        Console.WriteLine("\n\nDuck Number: " + IsDuckNumber(digits));
        Console.WriteLine("Armstrong Number: " + IsArmstrong(number, digits));

        FindLargestAndSecondLargest(digits);
        FindSmallestAndSecondSmallest(digits);
    }
}
