using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Работники".
    public class Employee
    {
        // Свойства класса.
        public int Id { get; set; }          // Идентификатор.
        public string Passport { get; set; } // Паспортные данные.
        public double Salary { get; set; }   // Зарплата.
        public virtual ICollection<Cell> Cells { get; set; } // Закреплённые за работником клетки.
        // О работниках птицефабрики в БД должна храниться следующая информация:
        // паспортные данные, зарплата, закрепленные за работником клетки.
    } // Employee.
}
