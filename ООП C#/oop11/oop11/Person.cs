using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class Person//Определить класс Person, который имеет 
    {
        private string _Name; //закрытое поле типа string, в котором хранится имя;
        private string _Surname;//закрытое поле типа string, в котором хранится фамилия
        private System.DateTime _Birthday;//закрытое поле типа System.DateTime для даты рождения

        //конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса
        public Person(string Name, string Surname, DateTime Birthday)
        {
            _Name = Name;
            _Surname = Surname;
            _Birthday = Birthday;
        }

        //конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию.
        public Person() : this("Джек", "Лондон", new DateTime(1998, 11, 12))
        {
        }

        // В классе Person определить свойства c методами get и set:
        //свойство типа string для доступа к полю с именем; 
        public string PersName
        {
            get
            {
                return _Name;
            }
        }

        //	свойство типа string для доступа к полю с фамилией;
        public string PersonSurname
        {
            get
            {
                return _Surname;
            }
        }

        //свойство типа DateTime для доступа к полю с датой рождения;
        public DateTime PersonBirthday
        {
            get
            {
                return _Birthday;
            }
        }

        //свойство типа int c методами get и set для получения информации(get) и изменения(set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения.
        public int intBirthday
        {
            get
            {
                return Convert.ToInt32(_Birthday);
            }
            set
            {
                _Birthday = Convert.ToDateTime(value);
            }
        }

        //перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;
        public override string ToString()
        {
            return string.Format("{0} {1} was born {2}", _Name, _Surname, _Birthday);
        }

        //	виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию.
        public string ToShortString()
        {
            return string.Format("{0} {1}", _Name, _Surname);
        }
        //контент 9 лабы переопределить (override) виртуальный метод bool Equals (object obj);
        public override bool Equals(object obj)
        {
            return ((Person)obj)?.GetHashCode() == GetHashCode();
        }
        //	переопределить виртуальный метод int GetHashCode();
        public override int GetHashCode()
        {
            return _Birthday.GetHashCode() + _Name.GetHashCode() + _Surname.GetHashCode();
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public object DeepCopy()
        {
            Person person = new Person(PersName, PersonSurname, PersonBirthday);

            return person;
        }
    }
}
