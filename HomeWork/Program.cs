using HomeworkAlgorithms;

namespace HomeWork;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("LUP-розкладання\n");

        double[,] A =
        {
            { 2, 7, -7, 7 },
            { 8, 8, 0, 4 },
            { -9, 0, -2, 3 },
            { 8, 4, 6, -4 }
        };

        double[] b = { 105, 92, -44, 20 };

        Print.PrintSystem(A, b);

        LupSolver solver = new LupSolver(A, b);
        solver.Decompose();
        double[] result = solver.Solve();

        Console.WriteLine("\nМатриця L:");
        Print.PrintMatrix(solver.L);

        Console.WriteLine("\nМатриця U:");
        Print.PrintMatrix(solver.U);

        Console.WriteLine("\nМатриця перестановок P:");
        Print.PrintArray(solver.P);

        Console.WriteLine("\nРозв'язок системи:");
        Print.PrintResult(result);

        Console.WriteLine("\nМетод Ейлера");
        EulerSolver euler = new EulerSolver();

        euler.Solve(
            x0: 0,
            y0: 1,
            z0: 0,
            h: 0.1,
            xEnd: 2
        );
    }
}