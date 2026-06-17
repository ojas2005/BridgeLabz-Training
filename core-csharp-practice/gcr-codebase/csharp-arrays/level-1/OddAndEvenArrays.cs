using System;
class OddAndEvenArrays{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if(number>0)
        {
            //initialising variables
            int size = (number/2)+1;
            int[] evenArr = new int[size];
            int[] oddArr = new int[size];
            int evenIndex = 0;
            int oddIndex = 0;

            //filling the values in evenArr and oddArr
            for(int i = 1;i<=number;i++)
            {
                if(i%2==0) //if i is even
                {
                    evenArr[evenIndex] = i;
                    evenIndex++;
                }
                else{ //if i is odd
                    oddArr[oddIndex] = i;
                    oddIndex++;
                }
            }
            //printing the even array
            Console.WriteLine("Even Elements array");
            for(int i = 0;i<evenIndex;i++)
            {
                Console.WriteLine($"{evenArr[i]}");
                
            }
            //printing the odd array
            Console.WriteLine("Odd Elements array");
            for(int i = 0;i<oddIndex;i++)
            {
                Console.WriteLine($"{oddArr[i]}");
                
            }


        }
        else{
            Console.WriteLine("Enter a Natural Number");
        }
    }
}