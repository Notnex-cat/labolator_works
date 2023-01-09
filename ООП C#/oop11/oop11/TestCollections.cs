using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class TestCollections
    {
        //Определить класс TestCollections, в котором в качестве типа TKey используется класс Team, а в качестве типа TValue - класс ResearchTeam. Класс содержит закрытые поля с коллекциями типов
        private List<Team> ListOfTeam = new List<Team>();
        private List<string> ListOfString = new List<string>();
        private Dictionary<Team, ResearchTeam> Team_Rea_Dict = new Dictionary<Team, ResearchTeam>();
        private Dictionary<string, ResearchTeam> String_Rea_Dict = new Dictionary<string, ResearchTeam>();

        public List<Team> ListTeam { get { return ListOfTeam; } set { ListOfTeam = value; } }
        private List<string> ListString { get { return ListOfString; } set { ListOfString = value; } }
        private Dictionary<Team, ResearchTeam> Team_Re_Dict { get { return Team_Rea_Dict; } set { Team_Rea_Dict = value; } }
        private Dictionary<string, ResearchTeam> String_Re_Dict { get { return String_Rea_Dict; } set { String_Rea_Dict = value; } }

        //	статический метод с одним целочисленным параметром типа int, который возвращает ссылку на объект типа ResearchTeam и используется для автоматической генерации элементов коллекций;
        public static ResearchTeam GenerateElement(int value)
        {
            ResearchTeam a = new ResearchTeam();
            a.RegistrationNumber = value;
            return a;
        }

        //•	конструктор c параметром  типа int (число элементов в коллекциях) для автоматического создания коллекций с заданным числом элементов;
        public TestCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                ResearchTeam rs = GenerateElement(i);
                ListOfTeam.Add(rs.Team);
                ListOfString.Add(rs.Team.ToString());
                Team_Rea_Dict.Add(rs.Team, rs);
                String_Rea_Dict.Add(rs.Team.ToString(), rs);

            }
        }

        //метод, который вычисляет время поиска элемента в списках List<Team> и List<string>, время поиска элемента по ключу и время поиска значения элемента в коллекциях-словарях Dictionary<Team, ResearchTeam> и Dictionary <string, ResearchTeam>.
        public void TimeOfSearching(string str, Team team, ResearchTeam resT)
        {
            int time1 = Environment.TickCount;
            ListOfTeam.BinarySearch(team);
            Console.WriteLine((time1 - Environment.TickCount).ToString());

            int time2 = Environment.TickCount;
            ListOfString.BinarySearch(str);
            Console.WriteLine((time2 - Environment.TickCount).ToString());

            int time3 = Environment.TickCount;
            ResearchTeam a = Team_Rea_Dict[team];
            Console.WriteLine((time3 - Environment.TickCount).ToString());

            int time4 = Environment.TickCount;
            ResearchTeam b = String_Rea_Dict[str];
            Console.WriteLine((time4 - Environment.TickCount).ToString());
            Console.WriteLine((time4 - Environment.TickCount).ToString());
        }
    }
}
