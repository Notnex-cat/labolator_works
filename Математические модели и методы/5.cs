//трапеции
double a = 0, b = 1, n = 400;
double x, h, s, y;
h = (b - a) / (n); //шаг
s = 0;
for (x = a + h / 2; x < b; x += h)
{
    y = x * Math.Cos(2 * x);
    s += y;
}
s *= h;
Console.WriteLine(s);
//Считаем при h2
double h2 = 2 * (b - a) / n; //шаг h2
double s1 = 0;
for (x = a + h2 / 2; x < b; x += h2)
{
    y = x * Math.Cos(2 * x);
    s1 += y * h2;
}
Console.WriteLine(s1);

Console.WriteLine(Math.Abs(s - s1) / 3.0);//правило  рунге

//симпсон
double b2, b1, n = 400;
static double f(double x)
{
    return x * Math.Cos(2 * x);
}

double x, a, b, h, h2, s, s1;
a = 0;
b = 1;
h = (b - a) / n;
s = 0;
x = h;
while (x < b)
{
    s += 4 * f(x);
    x += h;
    s += 2 * f(x);
    x += h;
}
b1 = h / 3 * (s + f(a) - f(b));// занесём 2 внутрь скобки, поэтому умножаем на 2 и 4
Console.WriteLine(" Интеграл(Метод Симпсона) h = {0}", b1);

h2 = 2 * (b - a) / n;
s1 = 0;
x = h2;
while (x < b)
{
    s1 += 4 * f(x);
    x += h2;
    s1 += 2 * f(x);
    x += h2;
}
b2 = h2 / 3 * (s1 + f(a) - f(b));
Console.WriteLine(" Интеграл(Метод Симпсона) 2h = {0}", b2);
Console.WriteLine("Метод Рунге= " + Math.Abs(b2 - b1) / 3.0);//runge


//Квадратурная формула прямоугольников
double f(double x)
{
    return x * Math.Cos(2 * x);
}

double a = 0, b = 1, n = 400, I = 0;

double h = (b - a) / n;
for (double x = a; x <= b; x += h)
{
    I += f(x - h / 2);
}
I *= h;

Console.WriteLine(I);



//Левых прямоуг
double f(double x)
{
    return x * Math.Cos(2 * x);
}
double a = 0, b = 1, n = 400, I = 0;

double h = (b - a) / n;
for (int i = 0; i <= n - 1; i++)
{
    I += f(a + i * h);
}
I *= h;
Console.WriteLine(I);


//Правых
double f(double x)
{
    return x * Math.Cos(2 * x);
}
double a = 0, b = 1, n = 400, I = 0;

double h = (b - a) / n;
for (int i = 1; i <= n; i++)
{
    I += f(a + i * h);
}
I *= h;
Console.WriteLine(I);
