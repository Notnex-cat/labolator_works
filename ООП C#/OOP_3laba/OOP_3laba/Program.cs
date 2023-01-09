/*using System;
using System.Collections.Generic;

var fiveInt = new List<int> { 1, 2, 3, 4 ,5};//объявил
fiveInt.ForEach(Console.WriteLine);//вывел
Console.WriteLine('\n');
fiveInt.Add(6);//добавил
fiveInt.ForEach(Console.WriteLine);//вывел снова

var threeInt = new List<int> { 9, 8, 7 };//объявил второй список
Console.WriteLine("Второй список");
threeInt.ForEach(Console.WriteLine);//вывел второй

Console.WriteLine('\n');
fiveInt.InsertRange(2, threeInt);
fiveInt.ForEach(Console.WriteLine);

Console.WriteLine("кол-во элементов");
Console.WriteLine(fiveInt.Count);

Console.WriteLine("масимальный элемент");
Console.WriteLine(fiveInt.Max());

Console.WriteLine("минимальный элемент");
Console.WriteLine(fiveInt.Min());

int[] mas = new int[3];
threeInt.CopyTo(mas);
Console.WriteLine("Massive");
for(int i = 0; i < mas.Length; i++)
{
    Console.WriteLine(mas[i]);
}

Console.WriteLine("после удаления 2 элемента");
threeInt.RemoveAt(1);
threeInt.ForEach(Console.WriteLine);//вывел второй*/

using System.IO;

string str = "язык программирования C#";
Console.WriteLine("строка: " + str);
string[] arr = str.Split();
Console.Write("зеркальный порядок слов: ");
for (int i = arr.Length - 1; i >= 0; i--) 
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();
Console.Write("обратный порядок: ");
for (int i = str.Length - 1; i >= 0; i--)
{
    Console.Write(str[i]);
}
Console.WriteLine('\n');

/*using System.IO;

string red = "Red Dead Redemption 2.";
int max = 1, k = 0;
char[] sep = { ' ' };
string[] parts = red.Split(sep);
for (int i = 0; i < parts.Length; i++)
{
    if (parts[i].Length > max)
    {
        max = parts[i].Length;
        k = i;
    }
}
string result = "";
Console.WriteLine(max);

for (int i = 0; i < red.Length; i++)
{
    if(red[i] < 65 || red[i] > 122)
    {
        result += red[i];
    }
    //Если буква является строчной
    if ((Convert.ToInt16(red[i]) >= 90) && (Convert.ToInt16(red[i]) <= 122))
    {
        //Если буква, после сдвига выходит за пределы алфавита
        if (Convert.ToInt16(red[i]) + max > 122)
            //Добавление в строку результатов символ
            result += Convert.ToChar(Convert.ToInt16(red[i]) + max - 26);
        //Если буква может быть сдвинута в пределах алфавита
        else
            //Добавление в строку результатов символ
            result += Convert.ToChar(Convert.ToInt16(red[i]) + max);
    }
    if ((Convert.ToInt16(red[i]) >= 65) && (Convert.ToInt16(red[i]) <= 90))
    {
        //Если буква, после сдвига выходит за пределы алфавита
        if (Convert.ToInt16(red[i]) + max > 90)
            //Добавление в строку результатов символ
            result += Convert.ToChar(Convert.ToInt16(red[i]) + max - 26);
        //Если буква может быть сдвинута в пределах алфавита
        else
            //Добавление в строку результатов символ
            result += Convert.ToChar(Convert.ToInt16(red[i]) + max);
    }
}
Console.WriteLine(result);*/