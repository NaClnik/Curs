using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, характеризующий цех.
    public class Shop
    {
        // Свойства класса.
        public int Id { get; set; }                          // Идентификатор.
        public virtual ICollection<Cell> Cells { get; set; } // Клетки, находящиеся в цеху.
        public ICollection<Employee> Employees { get; set; } // Работники, закреплённые за данным цехом.
    }
}
