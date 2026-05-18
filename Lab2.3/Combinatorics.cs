using System;

namespace Lab2._3
{
    public static class Combinatorics
    {
        public static long Factorial(int number) 
        {
            long result = 1; 

            for (int i = 2; i <= number; i++) 
            {
                result *= i;
            }

            return result;
        }

        public static long ArrangementWithoutRepetition(int n, int k)
        {
            return Factorial(n) / Factorial(n - k);
        }

        public static long ArrangementWithRepetition(int n, int k)
        {
            return (long)Math.Pow(n, k);
        }
    }
}