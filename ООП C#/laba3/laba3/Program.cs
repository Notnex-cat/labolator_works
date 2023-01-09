/*Console.WriteLine("Введите количество элементов массива");
int n = Convert.ToInt16(Console.ReadLine());
int[] a = new int[n];
Random rand = new Random();
int i = 0;
int sum = 0;
for (i = 0; i < n; i++)
{
    a[i] = rand.Next(-50, 100);
    Console.Write("{0, 4}", a[i]);
    if (a[i] < 0)
    {
        sum = 0;
    }
    else 
    { 
        sum += a[i];
    }
}
Console.WriteLine();
Console.WriteLine("Сумма элементов после последнего отрицательного:{0}", sum);
int k = 0;
Console.Write(" Введите С:");
int C = Convert.ToInt16(Console.ReadLine());

for (i = 0; i < n; i++)
    if (a[i] < C)
        k++;
Console.WriteLine("Количество чисел меньше числа С= {0}", k);*/

using System.Data.Common;

Random rand = new Random();
int k = 0;
Console.WriteLine("Введите количество строк масива");
int n = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Введите количество столбцов масива");
int m = Convert.ToInt16(Console.ReadLine());
int[,] mas = new int[n, m];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        mas[i, j] = rand.Next(-50, 100);
        
    }
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write("{0, 4}", mas[i, j]);
    Console.WriteLine('\n');
}
for (int j = 0; j < m; j++)
{
    for (int i = 0; i < n; i++)
    {
        if (mas[i, j] < 0)
        {
            k = 0;
            break;
        }
        k = k + mas[i, j];
    }
    Console.WriteLine("{0}", k);
}
for (int i = 0; i < n; i++)
{
    for (int j = m-2; j < m; j++)
    {
        int x = mas[i, j];
        mas[i, j] = mas[i, (m - 1)];
        mas[i, (m - 1)] = x;
    }
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write("{0, 4}", mas[i, j]);
    Console.WriteLine('\n');
}


/*using System;
Random rand = new Random();
int[][] A = new int[5][];
int sum = 0;

// выделение памяти для каждой строки
A[0] = new int[5]; 
A[1] = new int[3];
A[2] = new int[8];
A[3] = new int[4]; 
A[4] = new int[6];

for (int i = 0; i < A.Length; i++)
{
    for (int j = 0; j < A[i].GetLength(0); j++)
    {
        A[i][j] = rand.Next(-500, 500);
        Console.WriteLine("{0,4}", A[i][j]);
        sum = sum + A[i][j];
    }
    Console.Write('\n');
    Console.Write(sum);
    Console.Write('\n');
    Console.Write('\n');
    sum = 0;
}*/