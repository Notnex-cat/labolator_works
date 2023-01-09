//дихотомия
double e = 1e-6, h = 1e-2;//погрешность вычисления
double a = 2, b = 30;//интервал [2, 30]
int k = 0;//кол-во итераций
Console.WriteLine("_______________________________________");
Console.WriteLine("| Кол-во итераций |      Корень x      |");
Console.WriteLine("---------------------------------------");
while (b - a >= e)
{
    Console.WriteLine("|        {0, -9}| {1, -18} |", k, (a + b) / 2);//выводим таблицу
    double c = (a + b) / 2;
    if (f(c) - f(c + h) > 0)//> min, < max
        a = c;
    else
        b = c;
    k++;
}
Console.WriteLine("_______________________________________");

static double f(double x)
{
    return (double)(40 - 3 * x / 4 + x * x / 30 + 70 * x);
}


//метод координатного спуска
double d1(double x)
{
    double e = 1e-4, h = 0.6;//погрешность вычисления
    double a = -50, b = 50;//интервал
    while (b - a >= e)
    {
        double c = (a + b) / 2;
        if (f(x, c) - f(x, c + h) < 0)//> min, < max
            a = c;
        else
            b = c;
    }
    if (a < b) { return a; }
    else { return b; }
}

double d2(double x)
{
    double e = 1e-4, h = 0.6;//погрешность вычисления
    double a = -50, b = 50;//интервал 
    while (b - a >= e)
    {
        double c = (a + b) / 2;
        if (f(c, x) - f(c + h, x) < 0)//> min, < max
            a = c;
        else
            b = c;

    }
    if (a < b) { return a; }
    else { return b; }
}

double f(double x1, double x2)
{
    return 1 / ((x1 + 1) * (x1 + 1) + x2 * x2);
}


double eps = 1e-4;
double x1 = 2, x2 = 2.8, xt1 = 0, xt2 = 0;
do
{
    xt1 = x1;
    xt2 = x2;
    x2 = d1(x1);
    x1 = d2(x2);

} while (Math.Abs(xt1 - x1) > eps && Math.Abs(xt2 - x2) > eps);
Console.WriteLine("x1= " + x1 + " " + "x2= " + x2);