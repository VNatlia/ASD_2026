namespace HomeworkAlgorithms;

public static class Print
{
    public static void PrintSystem(double[,] A, double[] b)
    {
        Console.WriteLine("Система рівнянь:");

        int n = b.Length;

        for (int i = 0; i < n; i++)
        {
            Console.Write("| ");

            for (int j = 0; j < n; j++)
            {
                Console.Write($"{A[i, j]}x{j + 1}");

                if (j < n - 1)
                {
                    Console.Write(" + ");
                }
            }

            Console.WriteLine($" = {b[i]}");
        }
    }

    public static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],10:F4}");
            }

            Console.WriteLine();
        }
    }

    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }

    public static void PrintResult(double[] result)
    {
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine($"x{i + 1} = {result[i]:F4}");
        }
    }
}