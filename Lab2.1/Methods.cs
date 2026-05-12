using System;

namespace Lab2._1;

public class Methods
{
        public static double Rectangle(double a, double b, double h)
        {
            double sum = 0;

            for (double x = a; x < b; x = x + h)
            {
                sum = sum + Functions.F1(x);
            }

            return sum * h;
        }

        public static double Trapeze(double a, double b, double h)
        {
            double sum = (Functions.F1(a) + Functions.F1(b)) / 2;

            for (double x = a + h; x < b; x = x + h)
            {
                sum = sum + Functions.F1(x);
            }

            return sum * h;
        }

        public static double Simpson(double a, double b, double h)
        {
            int namberOfIntervals = (int)((b - a) / h);

            if (namberOfIntervals % 2 != 0)
            {
            namberOfIntervals = namberOfIntervals + 1;
            }

            h = (b - a) / namberOfIntervals;

            double sum = Functions.F1(a) + Functions.F1(b);

            for (int i = 1; i < namberOfIntervals; i++)
            {
                double x = a + i * h;

                if (i % 2 == 0)
                {
                    sum = sum + 2 * Functions.F1(x);
                }
                else
                {
                    sum = sum + 4 * Functions.F1(x);
                }
            }

            return sum * h / 3;
        }

        public static double Bisection(double a, double b, double eps)
        {
            double middleOfPoint = 0;

            while (Math.Abs(b - a) > eps)
            {
            middleOfPoint = (a + b) / 2;

                if (Functions.F2(a) * Functions.F2(middleOfPoint) < 0)
                {
                    b = middleOfPoint;
                }
                else
                {
                    a = middleOfPoint;
                }
            }

            return middleOfPoint;
        }

        public static double Newton(double currentApproximationOfTheRoot, double eps)
        {
            double next = currentApproximationOfTheRoot - Functions.F2(currentApproximationOfTheRoot) / Functions.DF2(currentApproximationOfTheRoot);

        while (Math.Abs(next - currentApproximationOfTheRoot) > eps)
            {
            currentApproximationOfTheRoot = next;
                next = currentApproximationOfTheRoot - Functions.F2(currentApproximationOfTheRoot) / Functions.DF2(currentApproximationOfTheRoot);
            }

            return next;
        }

        public static double Chord(double a, double b, double eps)
        {
            double newCurrentApproximationOfTheRootx = a;

            while (Math.Abs(Functions.F2(newCurrentApproximationOfTheRootx)) > eps)
            {
            newCurrentApproximationOfTheRootx = a - Functions.F2(a) * (b - a) / (Functions.F2(b) - Functions.F2(a));

                if (Functions.F2(a) * Functions.F2(newCurrentApproximationOfTheRootx) < 0)
                {
                    b = newCurrentApproximationOfTheRootx;
                }
                else
                {
                    a = newCurrentApproximationOfTheRootx;
                }
            }

            return newCurrentApproximationOfTheRootx;
        }

        public static void Euler(double x, double y, double xEnd, double h)
        {
            Console.WriteLine("\nТаблиця:");
            Console.WriteLine("x\t\ty");

            while (x <= xEnd)
            {
                Console.WriteLine($"{x:F2}\t\t{y:F5}");

                y = y + h * Functions.F3(x, y);
                x = x + h;
            }
        }
    }

