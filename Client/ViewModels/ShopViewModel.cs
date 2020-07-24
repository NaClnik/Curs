using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Client.Other;
using Client.Views;
using DataBaseAccess;
using DataBaseModels;

namespace Client.ViewModels
{
    class ShopViewModel
    {
        // Поля класса.
        private Shop _shop;
        private FarmContext _farmContext;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _closeWindowCommand;
        private RelayCommand _fillDockPanelCommand;

        // Свойства класса.
        public string WindowTitle { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        // Свойства команд класса.
        public RelayCommand CloseWindowCommand =>
            _closeWindowCommand ?? new RelayCommand(obj =>
            {
                var window = obj as Window;
                window?.Close();
            });

        public RelayCommand DragWindowCommand =>
            _dragWindowCommand ?? new RelayCommand(obj =>
            {
                var window = obj as Window;
                window?.DragMove();
            });

        public RelayCommand FillGridCommand =>
            _fillDockPanelCommand ?? new RelayCommand(obj =>
            {
                Grid grid = obj as Grid;

                if (!_shop.Cells.Any())
                    return;

                int maxRow = _shop.Cells.Max(v => v.RowNumber);
                int maxColumn = _shop.Cells.Max(v => v.CellNumber);

                for(int i = 0; i < maxRow; i++)
                    grid.RowDefinitions.Add(new RowDefinition());

                for(int i = 0; i < maxColumn; i++)
                    grid.ColumnDefinitions.Add(new ColumnDefinition());

                foreach (var item in _shop.Cells)
                {
                    Button button = new Button()
                    {
                        Content = $"Ряд {item.RowNumber}, номер {item.CellNumber}",
                        Margin = new Thickness(5)
                    };

                    button.Click += (sender, args) => new CellWindow(item, _farmContext).ShowDialog(); 

                    Grid.SetRow(button, item.RowNumber - 1);
                    Grid.SetColumn(button, item.CellNumber - 1);
                    grid.Children.Add(button);
                } // foreach.
            });


        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public ShopViewModel() { }

        // Конструктор с параметрами.
        public ShopViewModel(Shop shop, FarmContext context)
        {
            _farmContext = context;
            _shop = shop;
            
            var temp = new ObservableCollection<Employee>();
            foreach (var item in _shop.Cells)
                temp.Add(item.Employee);

            Employees = new ObservableCollection<Employee>(temp.Distinct());
            WindowTitle = $"Цех №{_shop.Id}";
        } // ctorf.
        #endregion
    } // ShopViewModel.
}
