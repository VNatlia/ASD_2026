using System;
using Lab2._1;

namespace Lab2_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Console.WriteLine("1 РІВЕНЬ. Обчислення інтеграла");
            Console.WriteLine("Функція: x * sqrt(2x + 1)");

            Console.Write("Введіть a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введіть b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введіть h: ");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("\nРезультати:");
            Console.WriteLine("Метод прямокутників: " + Methods.Rectangle(a, b, h));
            Console.WriteLine("Метод трапецій: " + Methods.Trapeze(a, b, h));
            Console.WriteLine("Метод Сімпсона: " + Methods.Simpson(a, b, h));


            Console.WriteLine("\n2 РІВЕНЬ. Пошук кореня рівняння");
            Console.WriteLine("Функція: x^5 + 5x + 1 = 0");

            Console.Write("Введіть ліву межу: ");
            double left = double.Parse(Console.ReadLine());

            Console.Write("Введіть праву межу: ");
            double right = double.Parse(Console.ReadLine());

            double eps = 0.0001;

            if (Functions.F2(left) * Functions.F2(right) > 0)
            {
                Console.WriteLine("На цьому інтервалі функція не змінює знак.");
                Console.WriteLine("Для цих методів краще взяти інтервал, де є один корінь.");
            }
            else
            {
                Console.WriteLine("\nРезультати:");
                Console.WriteLine("Метод половинчастого ділення: " + Methods.Bisection(left, right, eps));
                Console.WriteLine("Метод дотичних: " + Methods.Newton((left + right) / 2, eps));
                Console.WriteLine("Метод хорд: " + Methods.Chord(left, right, eps));
            }


            Console.WriteLine("\n3 РІВЕНЬ. Диференціальне рівняння");
            Console.WriteLine("dy/dx = e^(-x) - 2y");
            Console.WriteLine("Метод Ейлера");

            Console.Write("Введіть x0: ");
            double x0 = double.Parse(Console.ReadLine());

            Console.Write("Введіть y0: ");
            double y0 = double.Parse(Console.ReadLine());

            Console.Write("Введіть кінцеве x: ");
            double xEnd = double.Parse(Console.ReadLine());

            Console.Write("Введіть h: ");
            double h3 = double.Parse(Console.ReadLine());

            Methods.Euler(x0, y0, xEnd, h3);
        }
    }
}