using System;

class MatrixOperation
{
    // method to create random matrix
    public static double[,] CreateRandomMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];
        Random rand = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 10); // small values for simplicity
            }
        }
        return matrix;
    }

    // method to display matrix
    public static void DisplayMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(String.Format("{0,6}", matrix[i, j]));
            }
            Console.WriteLine();
        }
    }

    // method to add matrices
    public static double[,] AddMatrix(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    // method to subtract matrices
    public static double[,] SubtractMatrix(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    // method to multiply matrices
    public static double[,] MultiplyMatrix(double[,] a, double[,] b)
    {
        int r1 = a.GetLength(0);
        int c1 = a.GetLength(1);
        int c2 = b.GetLength(1);

        double[,] result = new double[r1, c2];

        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                for (int k = 0; k < c1; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    // method to find transpose
    public static double[,] TransposeMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] transpose = new double[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                transpose[j, i] = matrix[i, j];

        return transpose;
    }

    // determinant of 2x2 matrix
    public static double Determinant2x2(double[,] m)
    {
        return (m[0, 0] * m[1, 1]) - (m[0, 1] * m[1, 0]);
    }

    // determinant of 3x3 matrix
    public static double Determinant3x3(double[,] m)
    {
        double det =
            m[0,0] * (m[1,1] * m[2,2] - m[1,2] * m[2,1]) -
            m[0,1] * (m[1,0] * m[2,2] - m[1,2] * m[2,0]) +
            m[0,2] * (m[1,0] * m[2,1] - m[1,1] * m[2,0]);

        return det;
    }

    // inverse of 2x2 matrix
    public static double[,] Inverse2x2(double[,] m)
    {
        double det = Determinant2x2(m);
        double[,] inv = new double[2, 2];

        inv[0, 0] = m[1, 1] / det;
        inv[0, 1] = -m[0, 1] / det;
        inv[1, 0] = -m[1, 0] / det;
        inv[1, 1] = m[0, 0] / det;

        return inv;
    }

    // inverse of 3x3 matrix
    public static double[,] Inverse3x3(double[,] m)
    {
        double det = Determinant3x3(m);
        double[,] inv = new double[3, 3];

        inv[0,0] = (m[1,1]*m[2,2] - m[1,2]*m[2,1]) / det;
        inv[0,1] = (m[0,2]*m[2,1] - m[0,1]*m[2,2]) / det;
        inv[0,2] = (m[0,1]*m[1,2] - m[0,2]*m[1,1]) / det;

        inv[1,0] = (m[1,2]*m[2,0] - m[1,0]*m[2,2]) / det;
        inv[1,1] = (m[0,0]*m[2,2] - m[0,2]*m[2,0]) / det;
        inv[1,2] = (m[0,2]*m[1,0] - m[0,0]*m[1,2]) / det;

        inv[2,0] = (m[1,0]*m[2,1] - m[1,1]*m[2,0]) / det;
        inv[2,1] = (m[0,1]*m[2,0] - m[0,0]*m[2,1]) / det;
        inv[2,2] = (m[0,0]*m[1,1] - m[0,1]*m[1,0]) / det;

        return inv;
    }

    static void Main()
    {
        double[,] A = CreateRandomMatrix(3, 3);
        double[,] B = CreateRandomMatrix(3, 3);

        Console.WriteLine("Matrix A:");
        DisplayMatrix(A);

        Console.WriteLine("\nMatrix B:");
        DisplayMatrix(B);

        Console.WriteLine("\nAddition:");
        DisplayMatrix(AddMatrix(A, B));

        Console.WriteLine("\nSubtraction:");
        DisplayMatrix(SubtractMatrix(A, B));

        Console.WriteLine("\nMultiplication:");
        DisplayMatrix(MultiplyMatrix(A, B));

        Console.WriteLine("\nTranspose of A:");
        DisplayMatrix(TransposeMatrix(A));

        Console.WriteLine("\nDeterminant of A (3x3): " + Determinant3x3(A));

        Console.WriteLine("\nInverse of A:");
        DisplayMatrix(Inverse3x3(A));
    }
}
