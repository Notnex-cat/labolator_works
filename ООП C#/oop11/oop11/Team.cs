using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class Team : INameAndCopy, IComparable
    {
        protected string _Organisation;
        protected int _RegistrationNumber;

        // конструктор без параметров для инициализации по умолчанию;
        public Team(string Organisation, int RegistrationNumber)
        {
            _Organisation = Organisation;
            _RegistrationNumber = RegistrationNumber;
        }

        //свойство типа string для доступа к полю с названием организации
        public string Organisation
        {
            get
            {
                return _Organisation;
            }
            set
            {
                _Organisation = value;
            }
        }

        //свойство типа int для доступа к полю с номером регистрации
        public int RegistrationNumber
        {
            get
            {
                return _RegistrationNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Error! GroupNumber out of range(100, 599).");
                }
                else
                {
                    _RegistrationNumber = value;
                }
            }
        }

        string INameAndCopy.Name
        {
            get
            {
                return string.Format("Группа организации {0} с номером {1}", _Organisation, _RegistrationNumber);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Team() : this("Неизвестная организация", 1) { }

        //определить виртуальный метод object DeepCopy();
        public virtual object DeepCopy()
        {
            return new Team(this._Organisation, this._RegistrationNumber);
        }

        // переопределить (override) виртуальный метод bool Equals (object obj)
        public virtual bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Team objAsTeam = obj as Team;
            if (objAsTeam as Team == null)
            {
                return false;
            }
            return objAsTeam.Organisation == this.Organisation && objAsTeam.RegistrationNumber == this.RegistrationNumber;
        }

        // определить операции == и !=
        static public bool operator ==(Team l_Team, Team r_Team)
        {
            if (ReferenceEquals(l_Team, r_Team))
            {
                return true;
            }
            if ((((object)l_Team) == null) || (((object)r_Team) == null))
            {
                return false;
            }
            return false;

        }
        static public bool operator !=(Team l_Team, Team r_Team)
        {
            return !(l_Team == r_Team);
        }

        // переопределить виртуальный метод int GetHashCode();
        public virtual new int GetHashCode()
        {
            int HashCode = 0;
            foreach (char ch in _Organisation.ToCharArray())
            {
                HashCode += (int)Convert.ToUInt32(ch);
            }
            HashCode += _RegistrationNumber;
            return HashCode;
        }

        // перегруженную версию виртуального метода string ToString() для фор-мирования строки со значениями всех полей класса
        public virtual new string ToString()
        {
            return string.Format("Группа организации {0} с номером {1}", _Organisation, _RegistrationNumber);
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
