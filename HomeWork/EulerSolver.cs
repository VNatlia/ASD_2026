namespace HomeworkAlgorithms;

public class EulerSolver
{
    public void Solve(double x0, double y0, double z0, double h, double xEnd)
    {
        double x = x0;
        double y = y0;
        double z = z0;

        Console.WriteLine("\n x\t\t y\t\t z");
        Console.WriteLine("----------------------------------------");

        while (x <= xEnd)
        {
            Console.WriteLine($"{x:F2}\t\t{y:F4}\t\t{z:F4}");

            double dy = z;
            double dz = -y - 0.5 * z;

            y = y + h * dy;
            z = z + h * dz;

            x = x + h;
        }
    }
}