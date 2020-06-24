using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий статус.
    public class Status
    {
        public int Id { get; set; }
        public string StatusString { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Status() { }

        public Status(string statusString)
        {
            StatusString = statusString;
        } // ctorf.
    } // Status.
}
