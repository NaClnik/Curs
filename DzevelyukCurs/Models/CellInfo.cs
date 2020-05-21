using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzevelyukCurs.Models
{ 
    // Класс, содержащий информацию о клетке.
    public class CellInfo
    {
        // Поля класса.
        private int _shopNumber; // Номер цеха.
        private int _rowNumber;  // Номер ряда.
        private int _cellNumber; // Номер клетки в ряду.

        // Свойства класса.
        public int ShopNumber
        {
            get => _shopNumber;
            set => _shopNumber = value;
        } // ShopNumber.

        public int RowNumber
        {
            get => _rowNumber;
            set => _rowNumber = value;
        } // RowNumber.

        public int CellNumber
        {
            get => _cellNumber;
            set => _cellNumber = value;
        } // CellNumber.
    } // CellInfo.
}
