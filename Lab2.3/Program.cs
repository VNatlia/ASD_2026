using System;
using Lab2._3;

namespace Lab2._3
{
    class Program
    {
        static void Main()
        {
            TaskSolver solver = new TaskSolver();

            solver.FirstLevel();

            solver.SecondLevel();

            solver.ThirdLevel();
        }
    }
}