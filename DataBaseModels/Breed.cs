using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Породы".
    public class Breed
    {
        // Свойства класса.
        public int Id { get; set; }                                // Идентификатор.
        public string Title { get; set; }                          // Название.
        public int Performance { get; set; }                       // Среднее количество яиц в месяц.
        public double AverageWeight { get; set; }                  // Средний вес.
        public virtual Diet Diet { get; set; }                     // Рекомендованная диета.
        public virtual ICollection<Chicken> Chickens { get; set; } // Курицы данной породы.

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Breed() { }

        // Конструктор с параметрами.
        public Breed(string title, int performance, double averageWeight)
        {
            Title = title;
            Performance = performance;
            AverageWeight = averageWeight;
        } // ctorf.
    } // Breed.
}
