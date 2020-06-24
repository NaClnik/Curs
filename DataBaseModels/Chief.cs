using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Начальники".
    public class Chief
    {
        // Свойства класса.
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Shop Shop { get; set; }
    } // Chief.
}
