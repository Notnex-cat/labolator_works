Console.WriteLine("__________________________________________________");
Console.WriteLine("| №  |          x1          |          x2          |");
Console.WriteLine("--------------------------------------------------");
double x = -0.5, y = 1.5, q1, q2, e = 1e-6, x_0 = 0, y_0 = 0;
q1 = Math.Abs(fi1_dx(x, y)) + Math.Abs(fi1_dy(x, y));
q2 = Math.Abs(fi2_dx(x, y)) + Math.Abs(fi2_dy(x, y));
int i = 0;
while(Math.Abs(x-x_0) > e && Math.Abs(y-y_0) > e)
{
    x_0 = x;
    y_0 = y;
    x = fi1(x_0, y_0);
    y = fi2(x_0, y_0);
    i++;
    Console.WriteLine("| {0,-2} | {1,-20} | {2,-20} | ", i, x, y);
}
Console.WriteLine("__________________________________________________");

double fi1(double x, double y)//x1(x)
{
    return 0.6-Math.Sin(y);
}

double fi2(double x, double y)//x2(y)
{
    return -Math.Cos(y+x)/2;
}

double fi1_dx(double x, double y)
{
    return 0;
}

double fi1_dy(double x, double y)
{
    return -Math.Cos(y);
}

double fi2_dx(double x, double y)
{
    return Math.Sin(y+x)/2;
}

double fi2_dy(double x, double y)
{
    return Math.Sin(y + x) / 2;
}