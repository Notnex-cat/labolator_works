using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class ResearchTeam : Team, INameAndCopy, IComparable<ResearchTeam>, INotifyPropertyChanged//Определить класс ResearchTeam, который имеет 
    {
        private string Theme; // закрытое поле типа string c названием темы исследований;
        private string NameOfOrganisation; //	закрытое поле типа string с названием организации;
        private int RegNumber; //•	закрытое поле типа int – регистрационный номер;
        public TimeFrame ResearchDuration; //закрытое(уже нет) поле типа TimeFrame для информации о продолжительности исследований;

        //закрытое поле типа System.Collections.ArrayList для списка публикаций (объектов типа Paper).
        List<Person> ProjectParticipants = new List<Person>();
        List<Paper> Publications = new List<Paper>();
        public List<Paper> ListOfPublication { get { return Publications; } set { Publications = value; } }

        Random rand = new Random();

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Person> ListOfParticipants { get { return ProjectParticipants; } set { ProjectParticipants = value; } }
        //В классе ResearchTeam определить конструкторы:
        public ResearchTeam( string InvestigationTheme, string Organisation, int RegistrationNumber, TimeFrame InvestigationDuration)// конструктор c параметрами типа string, Person, DateTime для инициализации всех свойств класса
        {
            ResearchDuration = InvestigationDuration;
            Theme = InvestigationTheme;
            RegNumber = RegistrationNumber;
            NameOfOrganisation = Organisation;
           
        }

        //	конструктор без параметров, инициализирующий поля класса значениями по умолчанию.
        public ResearchTeam() {
            this.Theme = "Котики";
            NameOfOrganisation = "КГЭУ";
            ResearchDuration = TimeFrame.Year;
            RegNumber = rand.Next(0, 100);
        }

        public override string ToString()
        {
            string stringListOfPublications = "";
            foreach (Paper pap in Publications)
            {
                stringListOfPublications += pap.ToString() + "\r\n";
            }
            return string.Format("\r\n Тема: {0}, Длительность: {1} \r\n Организация:{2} \r\n Публикация: {3} \r\n Автор: {4}", Theme, ResearchDuration, NameOfOrganisation, stringListOfPublications, ProjectParticipants);
        }

        //виртуальный метод string ToShortString(), который формирует строку со значениями всех полей класса без списка публикаций.
        public string ToShortString()
        {
            return string.Format("\r\n Тема: {0}, Длительность: {1} \r\n Организация:{2} \r\n", Theme, ResearchDuration, NameOfOrganisation);
        }

        public object DeepCopy()
        {
            ResearchTeam other = (ResearchTeam)MemberwiseClone();
            other.NameOfOrganisation = string.Copy(NameOfOrganisation);
            other.ResearchDuration = ResearchDuration;
            other.Theme = string.Copy(Theme);
            other.RegNumber = RegNumber;
            other.Publications = new List<Paper>(Publications);
            other.ProjectParticipants = new List<Person>(ProjectParticipants);
            return other;
        }

        //метод void AddMembers ( params Person[] ) для добавления элементов в список участников проекта;
        public void AddMembers(params Person[] particips)
        {
            foreach (var item in particips)
            {
                ProjectParticipants.Add(item);
            }
        }

        public Team Team //свойство типа Team; метод get свойства возвращает объект типа Team, данные которого совпадают с данными подобъекта базового класса, метод set присваивает значения полям из подобъекта базового класса;
        {
            get
            {
                return new Team(NameOfOrganisation, RegNumber);
            }
            set
            {
                Organisation = value.Organisation;
                RegistrationNumber = value.RegistrationNumber;

            }
        }

        //итератор для последовательного перебора участников проекта (объектов типа Person), не имеющих публикаций;
        public IEnumerable<Person> MembersWithoutPublications()
        {

            ArrayList AutorsWithoutP = new ArrayList();
            bool Bool;
            foreach (Person pers in ProjectParticipants)
            {
                Bool = true;
                foreach (Paper pap in Publications)
                {
                    if (pap.Author == pers)
                    {
                        Bool = false;
                        break;
                    }
                }
                if (Bool)
                {
                    AutorsWithoutP.Add(pers);
                    Console.WriteLine(pers.ToShortString());
                }

            }
            for (int i = 0; i < AutorsWithoutP.Count; i++)
            {
                yield return (Person)AutorsWithoutP[i];
                Console.Write(((Person)AutorsWithoutP[i]).ToShortString());
            }
        }
        //итератор с параметром типа int для перебора публикаций, вышедших за последние n лет, в котором число n передается через параметр итератора.
        public IEnumerable<Paper> LastPapers(int N_years)
        {
            for (int i = 0; i < Publications.Count; i++)
            {
                if (((Paper)Publications[i]).Data.Year >= DateTime.Now.Year - N_years)
                {
                    yield return (Paper)Publications[i];
                    Console.Write(((Paper)Publications[i]).ToString());
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Person person in ProjectParticipants)
            {
                yield return person;
            }
        }

        public int CompareTo(ResearchTeam other)
        {
            if (other == null)
            {
                throw new ArgumentException("Wrong argument!");
            }
            return Theme.CompareTo(other.Theme);
        }
        delegate int KeySelector<TKey>(ResearchTeam rt);

        public string name 
        {
            get 
            { 
                return Theme;
            } 
            set
            { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("name")); ; this.Theme = value; 
            } 
        }
        public TimeFrame time
        { 
            get 
            { 
                return ResearchDuration;
            }
            set
            { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("time")); this.ResearchDuration = value; 
            } 
        }
        public enum Revision
        {
            Remove,
            Replace,
            Property
        }
        class ResearchTeamChangedEventArgs<TKey> : System.EventArgs
        {
            public string NameCollection { get; set; }

            public Revision InfoAboutEvent { get; set; }
            public string NamePropertyResearchTeam { get; set; }

            public int NumberRegisterResearchTeam { get; set; }
            public ResearchTeamChangedEventArgs(string str, Revision rev, string str1, int i)
            {
                NameCollection = str;
                InfoAboutEvent = rev;
                NamePropertyResearchTeam = str1;
                NumberRegisterResearchTeam = i;
            }

            public override string ToString()
            {
                return String.Format("Название коллекции - {0},\n Информация, чем вызвано событие: {1}\n Название свойства класса archTeam, которое является источником изменения данных элемента: {2}\n Номер регистрации объекта ResearchTeam {3}", NameCollection, InfoAboutEvent, NamePropertyResearchTeam, NumberRegisterResearchTeam);
            }
        }
    }
}