
class Program
{
    static void Main(string[] args)
    {
        int n = 4;
        double[,] m = new double[n, n];
        double[] f = new double[n];
        double[] x = new double[n]; //нулевые приближения
        for (int i = 0; i < n; i++)
        {
            x[i] = 0;
        }

        m[0, 0] = 4.238;
        m[0, 1] = 0.329;
        m[0, 2] = 0.256;
        m[0, 3] = 0.425;
        f[0] = 0.56;

        m[1, 0] = 0.249;
        m[1, 1] = 2.964;
        m[1, 2] = 0.351;
        m[1, 3] = 0.127;
        f[1] = 0.38;

        m[2, 0] = 0.365;
        m[2, 1] = 0.217;
        m[2, 2] = 2.897;
        m[2, 3] = 0.168;
        f[2] = 0.778;

        m[3, 0] = 0.178;
        m[3, 1] = 0.294;
        m[3, 2] = 0.432;
        m[3, 3] = 3.127;
        f[3] = 0.749;

        GaussZeidel test = new GaussZeidel(m, f, 500, n, x);
        bool IsDiagonal = test.DiagonallyDominant();
        test.algoritm();
        for (int j = 0; j < n; j++)
        {
            Console.WriteLine("X" + (j + 1) + " = " + test.roots[j]);
        }
        Console.WriteLine("\nКоличество итераций: " + test.k + "\n=====================================================================================================================");
    }
}

public class GaussZeidel
{
    public static double epsilon = 1e-6; //точность вычисления
    public int n, k, N; //N -допустимое число итераций, n - размерность квадратной матрицы коэффицентов, k-количество итераций
    public double s, Xi, diff = 1; //s - сумма, величина погрешности
    public double[,] matrix; //матрица коэффицентов
    public double[] value; //матрица значений
    public double[] roots; //матрица корней
    public bool diagonal;

    public GaussZeidel(double[,] matrix, double[] value, int N, int n, double[] roots)
    {
        this.matrix = matrix;
        this.N = N;
        this.value = value;
        this.n = n;
        this.roots = roots;
    }

    public bool DiagonallyDominant()
    {
        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    sum += Math.Abs(matrix[i, j]);
                }
            }
            if (Math.Abs(matrix[i, i]) >= sum)
            {
                diagonal = true;
                Console.WriteLine("Диагональные элементы равен больше суммы остальных элементов в каждой строке, условие сходимости выполнено");
                break;
            }
            else
            {
                diagonal = false;
            }
        }
        return diagonal;
    }

    double max = 0;
    double max1 = 0;

    public void algoritm()
    {
        Console.WriteLine("____________________________________________________________________________________________________________________");
        Console.WriteLine("| № |      Корень x1       |      Корень x2      |      Корень x3      |      Корень x4      |        delta X       |");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        k = 0;
        while ((k <= N) && (diff >= epsilon))
        {
            Console.Write("| {0} | ", k + 1);
            k = k + 1;
            for (int i = 0; i < n; i++)
            {
                s = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        s += matrix[i, j] * roots[j];
                    }
                }
                Xi = (value[i] - s) / matrix[i, i];
                diff = Math.Abs(Xi - roots[i]);
                roots[i] = Xi;
                Console.Write(" {0, -19} |", Xi);

                if (Xi > max)
                {
                    max = Xi;
                }
            }

            Console.WriteLine("{0, -21} |", Math.Abs(max - max1));
            max1 = max;
            max = 0;
        }
        Console.WriteLine("____________________________________________________________________________________________________________________\n");
    }
}