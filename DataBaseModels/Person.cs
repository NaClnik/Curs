using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataBaseModels
{
    // Класс, описывающий персону.
    public class Person
    {
        // Свойства класса.
        public int Id { get; set; }                                  // Идентификатор.
        public string Surname { get; set; }                          // Фамилия.
        public string Name { get; set; }                             // Имя.
        public string Patronymic { get; set; }                       // Отчество.
        public string Passport { get; set; }                         // Паспортные данные.
        public double Salary { get; set; }                           // Зарплата.
        public virtual Role Role { get; set; }                       // Роль работника.
        public virtual Status Status { get; set; }                   // Статус.
        public virtual Login Login { get; set; }                     // Логин.
        public virtual PasswordHash PasswordHash { get; set; }       // Пароль.
        public virtual ICollection<Employee> Employees { get; set; }

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Person() { }

        // Конструктор с параметрами.
        public Person(string surname, string name, string patronymic, string passport, double salary)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Passport = passport;
            Salary = salary;
        } // ctorf.

        public override string ToString() => $"{Surname} {Name[0]}.{Patronymic[0]}";
    } // Person.
}
