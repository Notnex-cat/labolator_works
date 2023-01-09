using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop11
{
    class Paper
    {
        public string Name { get; set; }
        public Person Author { get; set; }
        public DateTime Data { get; set; }

        public Paper(string name, Person author, DateTime data)
        {
            Name = name;
            Author = author;
            Data = data;
        }

        // конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию
        public Paper() : this("Мартин Иден", new Person(), new DateTime(1889, 6, 1))
        { }

        //   перегруженную версию виртуального метода string To-String() для формирования строки со значениями всех полей класса
        public override string ToString()
        {
            return string.Format("Author  {0} write book {1}. Data = {2}", Author, Name, Data);
        }

        public virtual object DeepCopy() //в классе Paper определить виртуальный метод object DeepCopy();
        {
            return new Paper(this.Name, this.Author, this.Data);
        }
        
    }
}
