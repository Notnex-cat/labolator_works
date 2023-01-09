Console.WriteLine("Введите х в градусах ");
double x = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите y в градусах");
double y = Convert.ToDouble(Console.ReadLine());
x = x * (Math.PI / 180);
y = y * (Math.PI / 180);
double res = Math.Pow(Math.Cos(x), 4) + Math.Pow(Math.Sin(y), 2) + 0.25 * Math.Pow(Math.Sin(2 * x), 2) - 1;
Console.WriteLine(res);

Console.WriteLine("Введите х в градусах ");
double x = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите y в градусах ");
double y = Convert.ToDouble(Console.ReadLine());
x = x * (Math.PI / 180);
y = y * (Math.PI / 180);
double res = Math.Sin(y - x) * Math.Sin(y - x);
Console.WriteLine(res);