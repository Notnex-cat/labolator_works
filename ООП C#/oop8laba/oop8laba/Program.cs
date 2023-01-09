using System.Collections;

public class Set
{
    int[] elements = new int[1];
    int count;

    static void Main(string[] args)
    {
        Set set = new Set();
        int[] r = new int[] { 1,2,3,4,5 };
        Set set1 = new Set(r);

        int[] g = new int[] { 3, 4, 5,6,7 };
        Set set2 = new Set(g);

        Console.Write("++ ");
        set.Pokaz(set1++);
        set1 = new Set(r);
        Console.WriteLine('\n');
        set1 = new Set(r);
        Console.Write("set1+set2 ");
        set.Pokaz(set1+set2);
        set1 = new Set(r);
        Console.WriteLine('\n');
        Console.Write("set1*set2 ");
        set.Pokaz(set1*set2);
        set1 = new Set(r);
        Console.WriteLine('\n');
        set1 = new Set(r);
        Console.Write("set1/set2 ");
        set.Pokaz(set1 / set2);
        set1 = new Set(r);
        Console.WriteLine('\n');
        Console.Write("set1<set2 ");
        Console.WriteLine( set1 < set2);
        set1 = new Set(r);
        Console.WriteLine('\n');
        Console.Write("set1>set2 ");
        Console.WriteLine(set1 > set2);
        set1 = new Set(r);


    }

    public void Pokaz(Set set1)
    {
        for (int i = 0; i < set1.elements.Length; i++)
        {
            Console.Write(set1.elements[i] + " ");
        }
    }
    public Set(int[] elements) {
        this.elements = elements;
    }
    public Set()
    {
        Console.Write("Введите количество элементов множества: ");
        count = Int32.Parse(Console.ReadLine());
        Array.Resize(ref elements, count);
        Console.WriteLine();
        Fill();
    }
    
    public void Fill()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите значение элемента №{i + 1}: ");
            elements[i] = Int32.Parse(Console.ReadLine()); 
        }
        ShowSet();
    }
    public int IndexOf(int value)
    {
        int t = 0;

        for (int i = 0; i < count; i++)
        {
            if (elements.Equals(value))
            {
                t = i;
                break;
            }
            else
            {
                t = -1;
            }
        }
        return t;
    }
    public void ShowSet()
    {
        foreach (var item in elements)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    public void Add(int newElement)
    {
        Array.Resize<int>(ref elements, elements.Length + 1);
        elements[elements.Length + 1] = newElement;
        count = elements.Length;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public static Set operator++ (Set set1)
    {
        for (int i = 0; i < set1.elements.Length; i++)
        {
            set1.elements[i]++;
        }
        return set1;
    }

    public static Set operator +(Set set1, Set set2) // Объединение множеств.
    {
        int[] tempArray = new int[1];

        int i = 1, j = 1, n = 0;
        while ((i < set1.elements.Length) && (j < set2.elements.Length))
        {
            if (set1.elements[i] < set2.elements[j])
            {
                tempArray[n++] = set1.elements[i++];
            }
            else if (set2.elements[j] < set1.elements[i])
            {
                tempArray[n++] = set2.elements[j++];
            }
            else
            {
                Array.Resize(ref tempArray, i);
                tempArray[n++] = set1.elements[i++];
                ++j;
            }
        }

        while (i < set1.elements.Length)
        {
            tempArray[n++] = set1.elements[i++];
        }

        while (j < set2.elements.Length)
        {
            Array.Resize(ref tempArray, i);
            tempArray[n++] = set2.elements[j++];
        }

        return new Set(tempArray);
    }

    public static Set operator *(Set set1, Set set2) //Пересечение множеств. ПОД ВОПРОСОМ!!!
    {
        int[] tempArray = new int[1];

        int d = 0;

        for (int i = 0; i < set1.elements.Length; i++)
        {
            int j = 0, k = 0;
            while (j < set2.elements.Length && set2.elements[j] != set1.elements[i])
            {
                j++;
            }

            while (k < d && tempArray[k] != set1.elements[i])
            {
                k++;
            }

            if (j != set2.elements.Length && k == d)
            {
                Array.Resize(ref tempArray, i);
                tempArray[d++] = set1.elements[i];
            }
        }

        return new Set(tempArray);
    }

    public static Set operator /(Set set1, Set set2) //Разность множеств.
    {
        int[] tempArray = new int[1];

        for (int i = 0; i < set1.elements.Length; i++)
        {
            int j = 0;
            while (j < set2.elements.Length && set2.elements[j] != set1.elements[i])
            {
                j++;
            }

            if (j == set2.elements.Length)
            {
                Array.Resize(ref tempArray, i+1);
                tempArray[i] = set1.elements[i];
            }
        }

        return new Set(tempArray);

    }

    public static bool operator <(Set set1, Set set2)
    {
        return set1.elements.Length < set2.elements.Length;
    }

    public static bool operator >(Set set1, Set set2)
    {
        return set1.elements.Length > set2.elements.Length;
    }

    public int this[int index] // Индексатор.
    {
        get
        {
            return elements[index];
        }
        set
        {
            elements[index] = value;
        }
    }
}