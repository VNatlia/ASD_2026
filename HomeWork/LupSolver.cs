namespace HomeWork;

public class LupSolver
{
    private readonly double[,] A;
    private readonly double[] b;
    private readonly int n;

    public double[,] L { get; private set; }
    public double[,] U { get; private set; }
    public int[] P { get; private set; }

    public LupSolver(double[,] matrix, double[] rightPart)
    {
        A = matrix;
        b = rightPart;
        n = b.Length;

        L = new double[n, n];
        U = new double[n, n];
        P = new int[n];
    }

    public void Decompose()
    {
        double[,] tempA = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            P[i] = i;

            for (int j = 0; j < n; j++)
            {
                tempA[i, j] = A[i, j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            double max = 0;
            int pivot = i;

            for (int j = i; j < n; j++)
            {
                if (Math.Abs(tempA[P[j], i]) > max)
                {
                    max = Math.Abs(tempA[P[j], i]);
                    pivot = j;
                }
            }

            int temp = P[i];
            P[i] = P[pivot];
            P[pivot] = temp;

            for (int j = i + 1; j < n; j++)
            {
                tempA[P[j], i] = tempA[P[j], i] / tempA[P[i], i];

                for (int k = i + 1; k < n; k++)
                {
                    tempA[P[j], k] =
                        tempA[P[j], k] -
                        tempA[P[j], i] * tempA[P[i], k];
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > j)
                {
                    L[i, j] = tempA[P[i], j];
                }
                else if (i == j)
                {
                    L[i, j] = 1;
                    U[i, j] = tempA[P[i], j];
                }
                else
                {
                    U[i, j] = tempA[P[i], j];
                }
            }
        }
    }

    public double[] Solve()
    {
        double[] y = new double[n];
        double[] x = new double[n];

        for (int i = 0; i < n; i++)
        {
            y[i] = b[P[i]];

            for (int j = 0; j < i; j++)
            {
                y[i] = y[i] - L[i, j] * y[j];
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            x[i] = y[i];

            for (int j = i + 1; j < n; j++)
            {
                x[i] = x[i] - U[i, j] * x[j];
            }

            x[i] = x[i] / U[i, i];
        }

        return x;
    }
}