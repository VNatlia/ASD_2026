using System;

namespace Lab2._3
{
    public class TaskSolver
    {
        public void FirstLevel()
        {
            Console.WriteLine("\tрівень 1");

            Console.WriteLine("спортивний гурток – 11 учасників.");
            Console.WriteLine("скільки є можливих варіантів складу команди з 4 спортсменів для естафети,");
            Console.WriteLine("де важлива послідовність учасників?");

            Console.Write("загальна кількість спортсменів (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("скільки мпортсменів ми вибираємо (k): ");
            int k = int.Parse(Console.ReadLine());

            long result = Combinatorics.ArrangementWithoutRepetition(n, k);

            Console.WriteLine("тип вибірки -розміщення без повторень-");

            Console.WriteLine($"відповідь: {result}");
        }

        public void SecondLevel()
        {
            Console.WriteLine("\n\tрівень 2");

            Console.WriteLine("цифри двійкової системи числення");
            Console.WriteLine("визначити кількість чисел розміром один байт.");

            Console.Write("кількість цифр (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("кількість розрядів (k): ");
            int k = int.Parse(Console.ReadLine());

            long result = Combinatorics.ArrangementWithRepetition(n, k);

            Console.WriteLine("тип вибірки -розміщення з повтореннями-");

            Console.WriteLine($"Відповідь: {result}");
        }

        public void ThirdLevel()
        {
            Console.WriteLine("\n\tрівень 3");

            int n = 11;
            int k = 4;

            int[] participants = new int[n];

            for (int i = 0; i < n; i++)
            {
                participants[i] = i + 1;
            }

            FileGenerator generator = new FileGenerator();

            generator.GenerateArrangements(
                participants,
                k,
                new int[k],
                new bool[n],
                0);

            generator.SaveToFile("arrangements.txt");

            Console.WriteLine("!файл створено!");

            Console.WriteLine($"кількість варіантів: {generator.Results.Count}");
        }
    }
}