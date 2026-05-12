using System;

namespace Lab2._1;

public class Functions
    {
        public static double F1(double x)
        {
            return x * Math.Sqrt(2 * x + 1);
        }

        public static double F2(double x)
        {
            return Math.Pow(x, 5) + 5 * x + 1;
        }

        public static double DF2(double x)
        {
            return 5 * Math.Pow(x, 4) + 5;
        }

        public static double F3(double x, double y)
        {
            return Math.Exp(-x) - 2 * y;
        }
    }

