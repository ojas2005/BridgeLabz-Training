using System;

class NumberCheckerIII
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

    // method to reverse digits array
    public static int[] ReverseArray(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        int j = 0;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            reversed[j] = digits[i];
            j++;
        }
        return reversed;
    }

    // method to compare two arrays
    public static bool CompareArrays(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        return true;
    }

    // method to check palindrome number
    public static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseArray(digits);
        return CompareArrays(digits, reversed);
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

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int[] digits = StoreDigits(number);

        Console.WriteLine("\nDigits of the number:");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i] + " ");
        }

        int[] reversedDigits = ReverseArray(digits);

        Console.WriteLine("\n\nReversed digits:");
        for (int i = 0; i < reversedDigits.Length; i++)
        {
            Console.Write(reversedDigits[i] + " ");
        }

        Console.WriteLine("\n\nArrays Equal: " + CompareArrays(digits, reversedDigits));
        Console.WriteLine("Palindrome Number: " + IsPalindrome(digits));
        Console.WriteLine("Duck Number: " + IsDuckNumber(digits));
    }
}
