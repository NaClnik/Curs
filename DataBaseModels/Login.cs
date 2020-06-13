using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Логины". 
    public class Login
    {
        // Свойства класса.
        public int Id { get; set; }
        public string LoginString { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    } // Login.
}
