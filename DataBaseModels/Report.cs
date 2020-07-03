using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу отчёта за день.
    public class Report
    {
        // Свойства класса.
        public int Id { get; set; }                  // Идентификатор. 
        public int Eggs { get; set; }                // Кол-во яиц, принесённых за день.
        public DateTime Date { get; set; }           // Дата отчёта.
        public virtual Chicken Chicken { get; set; } // Курица, по которой идёт отчёт.

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Report() { }

        // Конструктор с параметрами.
        public Report(int eggs, DateTime date)
        {
            Eggs = eggs;
            Date = date;
        } // ctorf.
    } // Report.
}
