using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ScottPlot;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        int N = 100;
        int[] sizes = { N, N * N, N * N * N };

        
        string level1Csv = "Кількість елементів,Час Counting Sort (нс)\n";

        foreach (int size in sizes)
        {
            int[] array = GenerateArray(size);

            long time = GetAverageTime(() =>
            {
                int[] copy = (int[])array.Clone();
                CountingSort(copy);
            });

            Console.WriteLine($"Кількість елементів: {size}");
            Console.WriteLine($"Час виконання: {time} нс\n");

            level1Csv += $"{size},{time}\n";
        }

        File.WriteAllText("level1.csv", level1Csv);

        Console.WriteLine("РІВЕНЬ 2");
        Console.WriteLine("Порівняння двох алгоритмів:");
        Console.WriteLine("1) Сортування розподіленого підрахунку");
        Console.WriteLine("2) Порозрядне сортування\n");

        string level2Csv = "Кількість елементів,Counting Sort (нс),Radix Sort (нс)\n";

        foreach (int size in sizes)
        {
            int[] array = GenerateArray(size);

            long countingTime = GetAverageTime(() =>
            {
                int[] copy = (int[])array.Clone();
                CountingSort(copy);
            });

            long radixTime = GetAverageTime(() =>
            {
                int[] copy = (int[])array.Clone();
                RadixSort(copy);
            });

            Console.WriteLine($"Кількість елементів: {size}");
            Console.WriteLine($"Counting Sort: {countingTime} нс");
            Console.WriteLine($"Radix Sort: {radixTime} нс\n");

            level2Csv += $"{size},{countingTime},{radixTime}\n";
        }

        File.WriteAllText("level2.csv", level2Csv);

        Console.WriteLine("РІВЕНЬ 3");
        Console.WriteLine("Порівняння часу для різного розташування елементів\n");

        int level3Size = 10000;

        int[] randomArray = GenerateArray(level3Size);
        int[] sortedArray = (int[])randomArray.Clone();
        Array.Sort(sortedArray);

        int[] reversedArray = (int[])sortedArray.Clone();
        Array.Reverse(reversedArray);

        string level3Csv = "Тип набору,Counting Sort (нс),Radix Sort (нс)\n";

        TestLevel3("Випадковий порядок", randomArray, ref level3Csv);
        TestLevel3("Відсортований порядок", sortedArray, ref level3Csv);
        TestLevel3("Зворотний порядок", reversedArray, ref level3Csv);

        File.WriteAllText("level3.csv", level3Csv);

        Console.WriteLine("CSV-файли створено:");
        Console.WriteLine("level1.csv");
        Console.WriteLine("level2.csv");
        Console.WriteLine("level3.csv");
    
    }

    static int[] GenerateArray(int size)
    {
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(0, 100000);
        }

        return array;
    }

    static void CountingSort(int[] array)
    {
        int max = array.Max();

        int[] count = new int[max + 1];

        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        int index = 0;

        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                array[index] = i;
                index++;
                count[i]--;
            }
        }
    }

    static void RadixSort(int[] array)
    {
        int max = array.Max();

        for (int digit = 1; max / digit > 0; digit *= 10)
        {
            CountingSortByDigit(array, digit);
        }
    }

    static void CountingSortByDigit(int[] array, int digit)
    {
        int[] result = new int[array.Length];
        int[] count = new int[10];

        for (int i = 0; i < array.Length; i++)
        {
            int digitValue = (array[i] / digit) % 10;
            count[digitValue]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            int digitValue = (array[i] / digit) % 10;
            result[count[digitValue] - 1] = array[i];
            count[digitValue]--;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = result[i];
        }
    }

    static long GetAverageTime(Action action)
    {
        int repeats = 5;
        long totalTime = 0;

        for (int i = 0; i < repeats; i++)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            action();

            stopwatch.Stop();

            long nanoseconds = stopwatch.ElapsedTicks * 1_000_000_000 / Stopwatch.Frequency;
            totalTime += nanoseconds;
        }

        return totalTime / repeats;
    }

    static void TestLevel3(string name, int[] array, ref string csv)
    {
        long countingTime = GetAverageTime(() =>
        {
            int[] copy = (int[])array.Clone();
            CountingSort(copy);
        });

        long radixTime = GetAverageTime(() =>
        {
            int[] copy = (int[])array.Clone();
            RadixSort(copy);
        });

        Console.WriteLine(name);
        Console.WriteLine($"Counting Sort: {countingTime} нс");
        Console.WriteLine($"Radix Sort: {radixTime} нс\n");

        csv += $"{name},{countingTime},{radixTime}\n";


       // графік
        double[] x = { 100, 10000, 1000000 };

        double[] counting =
        {
    228433,
    360175,
    6109141
};

        double[] radix =
        {
    45483,
    396133,
    42567216
};

        var plot = new ScottPlot.Plot();

        plot.Add.Scatter(x, counting);
        plot.Add.Scatter(x, radix);

        plot.Title("Порівняння алгоритмів");
        plot.XLabel("Кількість елементів");
        plot.YLabel("Час виконання (нс)");

        plot.SavePng("../../../graph.png", 1000, 600);

        Console.WriteLine("Графік створено!");
    }
}
