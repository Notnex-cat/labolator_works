using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using static oop11.ResearchTeam;

namespace oop11
{
    class ResearchTeamChangedEventArgs : System.EventArgs
    {
        //типа string с названием коллекции;
        public string NameCollection { get; set; }

        //•	типа Revision c информацией о типе события;
        public Revision InfoAboutEvent { get; set; }

        //типа string с названием свойства класса ResearchTeam, которое явилось причиной изменения данных элемента
        public string NamePropertyResearchTeam { get; set; }

        //типа int с номером регистрации объекта ResearchTeam для удаленного элемента или элемента, данные которого были изменены
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
