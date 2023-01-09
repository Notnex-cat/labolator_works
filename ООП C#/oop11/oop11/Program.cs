using System.Collections;
using System.Security.Cryptography;
using System.Xml.Linq;
using oop11;

enum TimeFrame { Year, TwoYears, Long } //Определить тип TimeFrame  - перечисление(enum) со значениями Year, TwoYears, Long.
class Program
{
    static void Main(string[] args)
    {
        //Console.BackgroundColor = ConsoleColor.White;
        //Console.ForegroundColor = ConsoleColor.Green;

        //1.	Создать две коллекции ResearchTeamCollection
        ResearchTeamCollection<string> researchTeamString1 = new ResearchTeamCollection<string>("First Collection");
        ResearchTeamCollection<string> researchTeamString2 = new ResearchTeamCollection<string>("2 Collection");
        ResearchTeamCollection<string> researchTeamString = new ResearchTeamCollection<string>("2 Collection");

        //2.	Создать объект TeamsJournal
        TeamsJournal journal1 = new TeamsJournal();

        researchTeamString1.ResearchTeamChanged += journal1.ResearchTeamChanged;
        researchTeamString2.ResearchTeamChanged += journal1.ResearchTeamChanged;

        researchTeamString1.AddDefaults();
        researchTeamString2.CollectionName = "new collection name";
        var rt = new ResearchTeam();
        researchTeamString2.AddResearchTeams(rt);
        rt.PropertyChanged += journal1.ResearchTeamPropertyHandler;
        researchTeamString2.Remove(rt);
        rt.PropertyChanged -= journal1.ResearchTeamPropertyHandler;
        researchTeamString2.AddResearchTeams(rt);

        researchTeamString1.Replace(rt, new ResearchTeam());
        researchTeamString1.Remove(new ResearchTeam());

        rt.name = "new name";

        Console.WriteLine(journal1.ToString());




        Hello message = () => Show_Message();//лямбда выражение можно и i * i писать
        message();
    }
    
    delegate void Hello(); // делегат без параметров

    private static void Show_Message()
    {
        Console.WriteLine("Привет мир!");
    }
}

//class Program
//{
//    delegate bool IsEqual(int x);
//    static void Main(string[] args)
//    {
//        int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//        // найдем сумму чисел больше 5
//        int result1 = Sum(integers, x => x > 5);
//        Console.WriteLine(result1); // 30
//                                    // найдем сумму четных чисел
//        int result2 = Sum(integers, x => x % 2 == 0);
//        Console.WriteLine(result2); //20
//    }
//    private static int Sum(int[] numbers, IsEqual func)
//    {
//        int result = 0;
//        foreach (int i in numbers)
//        {
//            if (func(i)) result += i;
//        }
//        return result;
//    }
//}