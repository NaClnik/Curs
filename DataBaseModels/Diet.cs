using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Диеты".
    public class Diet
    {
        // Свойства класса.
        public int Id { get; set; }                            // Идентификатор.
        public string DietTitle { get; set; }                  // Название диеты.
        public virtual ICollection<Breed> Breeds { get; set; } // Породы, которым рекомендована данная диета.
    } // Diet.
}
