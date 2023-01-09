using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class TeamListHandlerEventArgs : EventArgs
    {
        //открытое автореализуемое свойство типа string с названием коллекции, в которой произошло событие
        public string EventedCollectionName { get; set; }
        //открытое автореализуемое свойство типа string с информацией о типе изменений в коллекции
        public string EventInfo { get; set; }
        //открытое автореализуемое свойство типа int с номером элемента, который был добавлен или заменен
        public int ElementNumber { get; set; }
        //•	конструкторы для инициализации класса
        public TeamListHandlerEventArgs(string eventedCollectionName, string eventInfo, int elementNumber)
        {
            EventedCollectionName = eventedCollectionName;
            EventInfo = eventInfo;
            ElementNumber = elementNumber;
        }
        //•	конструкторы для инициализации класса
        public TeamListHandlerEventArgs() : this("SomCollection", "Some changes", 0) { }

        //перегруженную версию метода string ToString() для формирования строки с информацией обо всех полях класса
        public override string ToString()
        {
            return $"Name of collection that throw event: {EventedCollectionName}\nEvent Info:\n\t{EventInfo}\nNumber of collection element, where event was thrown: {ElementNumber}";
        }
    }
}
