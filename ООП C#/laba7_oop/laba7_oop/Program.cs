using System.Text;

    Stack<string> stack = new Stack<string>();
   
    string line = File.ReadAllText("D:\\лаба\\БД\\Документ Microsoft Word.txt", Encoding.Default);
    string[] words = line.Split(new string[] { " ", "\r\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
    int maxlength = 0;
    for (int i = 0; i < words.Length; i++)
        if (maxlength < words[i].Length) maxlength = words[i].Length;
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Length == maxlength && !stack.Contains(words[i])) stack.Push(words[i]);
    }
    string[] maxwords = stack.ToArray();
    int count;
    for (int i = 0; i < maxwords.Length; i++)
    {
        count = 0;
        foreach (string x in words)
        {
            if (x == maxwords[i]) ++count;
        }
        Console.WriteLine("{2}. Самое длинное слово: {0}\n   Число вхождений: {1}", maxwords[i], count, i);
    }
    Console.ReadKey(true);


/*using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace two_two
{
    class Program
    {

        
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\Notnex\\Desktop\\out.txt");
            string[] args2;
            List<string> vv2 = new List<string>();
            List<string> vv3 = new List<string>();

            string pathread = "C:\\Users\\Notnex\\Desktop\\in.txt";

            string[] line; //массив строк читаемого файла
            List<string> vivod = new List<string>();
            
            args2 = args;
            
            line = new string[File.ReadAllLines(pathread).Length];
            line = File.ReadAllLines(pathread, Encoding.Default);

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Contains("хоккей"))
                {
                    line[i]=line[i].Replace("хоккей", "");
                    writer.WriteLine("хоккей " + line[i]);
                    Console.WriteLine("хоккей " + line[i]);
                }
            }
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Contains("футбол"))
                {
                    line[i] = line[i].Replace("футбол", "");
                    Console.WriteLine("футбол " + line[i]);
                    writer.WriteLine("футбол " + line[i]);
                }
            }
            writer.Close();
        }
    }
    
}*/