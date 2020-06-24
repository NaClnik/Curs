using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, характеризующий клетку.
    public class Cell
    {
        // Свойства класса.
        public int Id { get; set; }                                // Идентификатор.
        public int RowNumber { get; set; }                         // Номер ряда.
        public int CellNumber { get; set; }                        // Номер клетки.
        public virtual Shop Shop { get; set; }                     // Цех, в котором находится клетка.
        public virtual Employee Employee { get; set; }             // Работник, закреплённый за этой клеткой.
        public virtual ICollection<Chicken> Chickens { get; set; } // Курицы, живущие в клетке.

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Cell() { }

        // Конструктор с параметрами.
        public Cell(int rowNumber, int cellNumber)
        {
            RowNumber = rowNumber;
            CellNumber = cellNumber;
        } // ctorf.
    } // Cell.
}
