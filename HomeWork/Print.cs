namespace HomeWork;

public static class Print
{
    public static void PrintSystem(double[,] A, double[] b)
    {
        Console.WriteLine("Система рівнянь:");

        for (int i = 0; i < b.Length; i++)
        {
            Console.Write("| ");

            for (int j = 0; j < b.Length; j++)
            {
                Console.Write($"{A[i, j]}x{j + 1}");

                if (j < b.Length - 1)
                {
                    Console.Write(" + ");
                }
            }

            Console.WriteLine($" = {b[i]}");
        }
    }

    public static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
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