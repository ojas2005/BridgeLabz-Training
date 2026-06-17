using System;
 class TwoDimensionToOne
    {
         static void Main(String[] args)
        {
            //taking input of rows and columns for 2D array
            int rows  = int.Parse(Console.ReadLine());
            int columns  = int.Parse(Console.ReadLine());
            int[,] twoDimensionArray = new int[rows,columns];
            for (int i = 0; i < twoDimensionArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionArray.GetLength(1); j++)
                {
                    twoDimensionArray[i, j] = int.Parse(Console.ReadLine());
                }
            }
            //converting our twoDimensionArray array to oneDimensionArray array
            int[] oneDimensionArray = new int[twoDimensionArray.Length];

            for (int i = 0; i < twoDimensionArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionArray.GetLength(1); j++)
                {
                    oneDimensionArray[(i * twoDimensionArray.GetLength(1)) + j] = twoDimensionArray[i, j];

                }
            }
            //printing oneDimensionArray array

            for (int i = 0; i < oneDimensionArray.Length; i++)
            {
                Console.Write(oneDimensionArray[i]);
            }

        }
    }