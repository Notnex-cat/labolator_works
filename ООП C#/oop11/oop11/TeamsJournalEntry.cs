using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class TeamsJournalEntry
    {
        //типа string с названием коллекции
        public string EventedCollectionName { get; set; }
        //типа string с названием свойства класса ResearchTeam, которое явилось причиной изменения данных элемента;
        public string EventInformation { get; set; }
        //типа int с номером регистрации объекта ResearchTeam для удаленного элемента или элемента, данные которого были изменены
        public int ElementNumber { get; set; }
        
        public string PropertyName { get; set; }

        //конструктор для инициализации полей класса
        public TeamsJournalEntry(string eventInformation, string propertyName)
        {
            EventInformation = eventInformation;
            PropertyName = propertyName;
        }

        public TeamsJournalEntry(string collectionName, string eventInformation, string propertyName, int registrationNumber)
        {
            EventedCollectionName = collectionName;
            EventInformation = eventInformation;
            PropertyName = propertyName;
            ElementNumber = registrationNumber;
        }

        //перегруженную версию метода string ToString()
        public override string ToString()
        {
            return string.Format("Название коллекции: {0} \n Событие: {1} \n Кол-во элементов {2} \n", this.EventedCollectionName, this.EventInformation, this.ElementNumber);
        }
    }
}
