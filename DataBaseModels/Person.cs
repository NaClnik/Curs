using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий персону.
    public class Person
    {
        // Свойства класса.
        public int Id { get; set; }                          // Идентификатор.
        public string Name { get; set; }                     // Имя.
        public string Surname { get; set; }                  // Фамилия.
        public string Patronymic { get; set; }               // Отчество.
        public string Passport { get; set; }                 // Паспортные данные.
        public double Salary { get; set; }                   // Зарплата.
        public virtual Login Login { get; set; }
        public virtual PasswordHash PasswordHash { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Chief> Chiefs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    } // Person.
}
