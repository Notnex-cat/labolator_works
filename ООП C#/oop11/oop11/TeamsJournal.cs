using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class TeamsJournal
    {
        //закрытое поле List<TeamsJournalEntry> для  списка изменений
        private List<TeamsJournalEntry> ListOfChanges = new List<TeamsJournalEntry>();
        public void TeamEventHandler(object source, TeamListHandlerEventArgs args)
        {
            ListOfChanges.Add(new TeamsJournalEntry(args.EventedCollectionName, "ReserchTeam was changed", args.EventInfo, args.ElementNumber));
        }

        //обработчик события ResearchTeamsChanged;  обработчик использует информацию, которая передается ему через объект ResearchTeamsChangedEventArgs, создает элемент TeamJournalEntry и добавляет его к списку List<TeamsJournalEntry>
        public void ResearchTeamChanged(object source, ResearchTeamChangedEventArgs args)
        {
            ListOfChanges.Add(new TeamsJournalEntry(args.NameCollection, "ReserchTeam was changed", args.NamePropertyResearchTeam, args.NumberRegisterResearchTeam));
        }
        public void ResearchTeamPropertyHandler(object source, PropertyChangedEventArgs args)
        {
            ListOfChanges.Add(new TeamsJournalEntry("Property was changed", args.PropertyName));
        }

        //перегруженную версию метода string ToString() для формирования строки с информацией обо всех элементах списка List<TeamsJournalEntry>
        public override string ToString()
        {
            string str = "";
            foreach (TeamsJournalEntry en in ListOfChanges)
            {
                str += en.ToString() + "\n";
            }
            return str;
        }
    }
}
