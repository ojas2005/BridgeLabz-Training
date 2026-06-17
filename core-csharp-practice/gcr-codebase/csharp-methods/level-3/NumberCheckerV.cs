using System;

class NumberCheckerV
{
    // method to find factors of a number and return as array
    public static int[] FindFactors(int number)
    {
        int count = 0;

        // first loop to count factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        // second loop to store factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index] = i;
                index++;
            }
        }

        return factors;
    }

    // method to find greatest factor
    public static int GreatestFactor(int[] factors)
    {
        int max = Int32.MinValue;

        for (int i = 0; i < factors.Length; i++)
        {
            if (factors[i] > max)
                max = factors[i];
        }
        return max;
    }

    // method to find sum of factors
    public static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += factors[i];
        }
        return sum;
    }

    // method to find product of factors
    public static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        for (int i = 0; i < factors.Length; i++)
        {
            product *= factors[i];
        }
        return product;
    }

    // method to find product of cube of factors
    public static double ProductOfCubeOfFactors(int[] factors)
    {
        double product = 1;

        for (int i = 0; i < factors.Length; i++)
        {
            product *= Math.Pow(factors[i], 3);
        }
        return product;
    }

    // method to check perfect number
    public static bool IsPerfectNumber(int number, int[] factors)
    {
        int sum = 0;

        // proper divisors (excluding the number itself)
        for (int i = 0; i < factors.Length; i++)
        {
            if (factors[i] != number)
                sum += factors[i];
        }

        return sum == number;
    }

    // method to check abundant number
    public static bool IsAbundantNumber(int number, int[] factors)
    {
        int sum = 0;

        for (int i = 0; i < factors.Length; i++)
        {
            if (factors[i] != number)
                sum += factors[i];
        }

        return sum > number;
    }

    // method to check deficient number
    public static bool IsDeficientNumber(int number, int[] factors)
    {
        int sum = 0;

        for (int i = 0; i < factors.Length; i++)
        {
            if (factors[i] != number)
                sum += factors[i];
        }

        return sum < number;
    }

    // method to check strong number
    // sum of factorial of digits == number
    public static bool IsStrongNumber(int number)
    {
        int temp = number;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }

        return sum == number;
    }

    // helper method to find factorial
    public static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("\nFactors:");
        for (int i = 0; i < factors.Length; i++)
        {
            Console.Write(factors[i] + " ");
        }

        Console.WriteLine("\n\nGreatest Factor: " + GreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + SumOfFactors(factors));
        Console.WriteLine("Product of Factors: " + ProductOfFactors(factors));
        Console.WriteLine("Product of Cube of Factors: " + ProductOfCubeOfFactors(factors));

        Console.WriteLine("\nPerfect Number: " + IsPerfectNumber(number, factors));
        Console.WriteLine("Abundant Number: " + IsAbundantNumber(number, factors));
        Console.WriteLine("Deficient Number: " + IsDeficientNumber(number, factors));
        Console.WriteLine("Strong Number: " + IsStrongNumber(number));
    }
}
