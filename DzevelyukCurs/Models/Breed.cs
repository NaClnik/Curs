using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzevelyukCurs.Models
{
    // Класс, описывающий таблицу "Породы".
    public class Breed
    {
        // Свойства класса.
        public int Id { get; set; } // Идентификатор.
        public string Title { get; set; } // Название.
        public int Performance { get; set; } // Среднее количество яиц в месяц.
        public double AverageWeight { get; set; } // Средний вес.
        public virtual Diet Diet { get; set; } // Рекомендованная диета.
        // Сведения о породе включают в себя: название породы,
        // среднее количество яиц в месяц(производительность)
        // и средний вес, номер рекомендованной диеты.
    } // Breed.
}
