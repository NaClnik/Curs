using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    public class Person
    {
        // Свойства класса.
        public int Id { get; set; }            // Идентификатор.
        public string Name { get; set; }       // Имя.
        public string Surname { get; set; }    // Фамилия.
        public string Patronymic { get; set; } // Отчество.
        public string Passport { get; set; }   // Паспортные данные.
        public double Salary { get; set; }     // Зарплата.
    } // Person.
}
