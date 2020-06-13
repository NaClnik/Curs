using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Хэш Паролей". 
    public class PasswordHash
    {
        // Свойства класса.
        public int Id { get; set; }
        public string PasswordHashString { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    } // Password.
}
