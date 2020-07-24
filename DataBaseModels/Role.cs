using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    public class Role
    {
        // Свойства класса.
        public int Id { get; set; }
        public string RoleString { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        // Ансамбль конструкторов.
        public Role() { }

        // Конструктор с параметрами.
        public Role(string roleString)
        {
            RoleString = roleString;
        }
    } // Role.
}
