using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccess;
using DataBaseModels;

namespace Client.ViewModels
{
    public class CreateCellViewModel
    {
        // Свойства класса.
        public Shop Shop { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public int RowNumber { get; set; }
        public int CellNumber { get; set; }

        // Поля команд класса.

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public CreateCellViewModel() { }

        // Конструктор с параметрами.
        public CreateCellViewModel(Shop shop)
        {
            Shop = shop;

            var temp = new ObservableCollection<Employee>();
            foreach (var item in Shop.Cells)
                temp.Add(item.Employee);

            Employees = new ObservableCollection<Employee>(temp.Distinct());
        } // ctorf.
    } // CreateCellViewModel.
}
