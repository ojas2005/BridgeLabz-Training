using System;
    class PositiveNegativeZero{
        static void Main()
        {
            int[] arr = new int[5];
            for(int i = 0;i<arr.Length;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if(arr[i]>0) //checking that if arr[i] is positive.
                {
                    if(arr[i]%2==0) //checking if arr[i] is even or odd.
                    {
                        Console.WriteLine($"The number {arr[i]} is positive even number");
                    }
                    else{ 
                        Console.WriteLine($"The number {arr[i]} is positive odd number");
                    }
                }
                else if(arr[i]==0) //checkin if arr[i] is zero
                {
                    Console.WriteLine($"The number {arr[i]} is Zero");
                }
                else{ 
                    Console.WriteLine($"The number {arr[i]} is a negative number");
                }
            }
            //comparing first and last elements of the array.
            if(arr[0]>arr[4]){
                Console.WriteLine($"First number {arr[0]} is greater than last number {arr[4]}");
            }
            else if(arr[4]>arr[0])
            {
                Console.WriteLine($"First number {arr[0]} is smaller than last number {arr[4]}");
            }
            else{
                Console.WriteLine($"First number {arr[0]} and last number {arr[4]} are equal");
            }
        }
    }
