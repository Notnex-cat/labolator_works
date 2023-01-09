using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static oop11.ResearchTeam;

namespace oop11
{
    class ResearchTeamCollection<TKey> : IEnumerable
    {
        private List<ResearchTeam> SomeResearchTeams = new List<ResearchTeam>();// акрытое поле типа System.Collections.Generic.List<ResearchTeam>;
                                                                                //открытое автореализуемое свойство типа string с названием коллекции
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        public ResearchTeamCollection(string name)
        {
            CollectionName = name;
            SomeResearchTeams = new List<ResearchTeam>();
        }
        //открытое автореализуемое свойство типа string с названием коллекции;
        public string CollectionName { get; set; }

        //метод bool Remove(ResearchTeam rt) для удаления элемента со значением rt из словаря Dictionary<TKey, ResearchTeam>; если в словаре нет элемента rt, метод возвращает значение false
        public bool Remove(ResearchTeam rt)
        {
            if (!SomeResearchTeams.Contains(rt))
                return false;
            SomeResearchTeams.Remove(rt);
            ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventArgs("ResearchTeamCollection", Revision.Remove, "ResearchTeam", rt.RegistrationNumber));
            return true;
        }

        //метод bool Replace(ResearchTeam rtold, ResearchTeam rtnew) для замены в словаре Dictionary<TKey, ResearchTeam > элемента со значением rtold на элемент со значением  rtnew; если в словаре нет элемента со значением rtold, метод возвращает значение false
        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            if (!SomeResearchTeams.Contains(rtold))
                return false;
            SomeResearchTeams[SomeResearchTeams.IndexOf(rtold)] = rtnew;
            ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventArgs("ResearchTeamCollection", Revision.Replace, "ResearchTeam", rtnew.RegistrationNumber));
            return true;
        }

        //событие ResearchTeamsChanged типа ResearchTeamsChangedHandler<TKey>, которое происходит, когда изменяется набор элементов в коллекции-словаре Dictionary<TKey,ResearchTeam> или изменяются данные одного из ее элементов
        public event ResearchTeamChangedHandler? ResearchTeamChanged;


        //метод void InsertAt (int j, ResearchTeam rt), который вставляет элемент rt в список List<ResearchTeam> перед элементом с номером j; если в списке нет элемента с номером j, метод добавляет элемент в конец списка
        public void InsertAt(int j, ResearchTeam rt)
        {
            if (SomeResearchTeams.Count < j)
            {
                SomeResearchTeams[SomeResearchTeams.Count - 1] = rt;
                ResearchTeamAdded(SomeResearchTeams[SomeResearchTeams.Count - 1], new TeamListHandlerEventArgs("Коллекция в InsertAt", "Last element added", SomeResearchTeams.Count - 1));
            }
            for (int i = 0; i < SomeResearchTeams.Count; i++)
            {
                if (i - 1 == j)
                {
                    SomeResearchTeams.Insert(i, rt);
                    ResearchTeamInserted(SomeResearchTeams[i], new TeamListHandlerEventArgs("Коллекция в InsertAt", "Element was added", j));
                }
            }
        }
        //индексатор типа ResearchTeam  (с методами get и set) с целочисленным индексом для доступа к элементу списка List<ResearchTeam> с заданным номером
        public ResearchTeam this[int index]
        {
            get { return SomeResearchTeams[index]; }
            set { SomeResearchTeams[index] = value; }
        }
        
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        public void AddDefaults()
        {
            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs("InsertEvent", "Item added as last (from AddDefaults func)", SomeResearchTeams.Count));
            SomeResearchTeams.Add(new ResearchTeam());
            SomeResearchTeams.Add(new ResearchTeam());
            SomeResearchTeams.Add(new ResearchTeam());
        }


        public void AddResearchTeams(params ResearchTeam[] rts)
        {
            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs("InsertEvent", "Item added as last (from AddResearchTeams func)", SomeResearchTeams.Count));
            SomeResearchTeams.AddRange(rts);
        }

        public int minNum
        {
            get
            {
                if (SomeResearchTeams.Count == 0) return -1;
                return SomeResearchTeams.Min((e) => e.RegistrationNumber);
            }
        }

        //перегруженную версию виртуального метода string ToString() для формирования строки c информацией обо всех элементах списка List<ResearchTeam>, которая содержит значения всех полей, список 
        public override string ToString()
        {
            string ResTeamString = "";
            foreach (ResearchTeam team in SomeResearchTeams)
            {
                ResTeamString += team.ToString();
            }
            return ResTeamString;
        }


        //по номеру регистрации с использованием интерфейса IComparable, реализованного в классе Team;
        public void ToSortByRegistrNumber()
        {
            SomeResearchTeams.Sort((x, y) => x.RegistrationNumber.CompareTo(y.RegistrationNumber));
        }
        //по названию темы исследований с использованием интерфейса IComparer<ResearchTeam>, реализованного в классе ResearchTeam;
        public void SortByString()
        {
            SomeResearchTeams.Sort();
        }
        //по числу публикаций с использованием интерфейса IComparer<ResearchTeam>, реализованного во вспомогательном классе.
        public void SortByPublications()
        {
            ResearchTeamComparer comp = new ResearchTeamComparer();
            SomeResearchTeams.Sort(comp);
        }
        //	свойство типа int (только с методом get), возвращающее минимальное значение номера регистрации для элементов списка List<ResearchTeam>;  
        public int MinRegNumber
        {
            get
            {
                if (SomeResearchTeams.Count == 0)
                {
                    return 0;
                }
                return SomeResearchTeams.Min(teams => teams.RegistrationNumber);
            }
        }

        //свойство типа IEnumerable<ResearchTeam> (только с методом get), возвращающее подмножество элементов списка List<ResearchTeam> с  продолжительностью исследований TimeFrame.TwoYears;  для формирования подмножества использовать метод Where класса  System.Linq.Enumerable;
        public IEnumerable<ResearchTeam> TwoYearsLong
        {
            get
            {
                IEnumerable<ResearchTeam> TwoTearsL = SomeResearchTeams.Where(time => time.ResearchDuration == TimeFrame.TwoYears);
                return TwoTearsL;
            }
        }

        //•	метод List<ResearchTeam> NGroup(int value), который возвращает список, в который входят элементы ResearchTeam из списка List<ResearchTeam> с заданным числом участников исследования; для формирования списка использовать методы Group и ToList класса  System.Linq.Enumerable.
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < SomeResearchTeams.Count; i++)
            {
                yield return SomeResearchTeams[i];
            }
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;

        public delegate void ResearchTeamChangedHandler(object source, ResearchTeamChangedEventArgs args);

    }
}
