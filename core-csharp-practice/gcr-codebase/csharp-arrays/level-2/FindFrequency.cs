using System;
 class FrequancyArray
    {
        static void Main(String[] args)
        {
            //taking number from the user
            int number = int.Parse(Console.ReadLine());
            int original = number;
            int count = 0;
            
            while(original!=0){
                original=original/10;
                count++;
            }
            int[] digits = new int[count];
            int[] freq = new int[count];
            int index = 0;
            original = number;
            //storing digits of number in digits array.
            while(original!=0)
            {
                digits[index] = original%10;
                original/=10;
                index++;
            }
            for(int i =0;i<count;i++) //initialising freq array
            {
                freq[i] = -1;
            }


            for (int i = 0;i<count;i++)
            {
                if(freq[i]!= -1) //checking if we've already checked that number or not
                {
                    continue; //if we've already checked,we will skip that index.
                }
                int f = 1;
                for(int j = i + 1; j < count; j++)
                {
                    if(digits[i] == digits[j])
                    {
                        //if digit is found then we increment the count and mark the freqency array at that index as 0.
                        f++; //increment
                        freq[j] = 0; //setting that index as 0.
                    }
                }
               
                    freq[i] = f;
                }
            
            //printing the frequency of each digit
            for(int i = 0;i<count;i++)
            {
                if(freq[i]!=0)
                {
                    Console.WriteLine("Frequency of " + digits[i] + " is" + freq[i]);
                }
            }


        }
    }
