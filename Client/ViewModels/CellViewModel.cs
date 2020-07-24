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
    class CellViewModel
    {
        // Поля класса.
        private Cell _cell;
        private FarmContext _farmContext;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _closeWindowCommand;
        private RelayCommand _chickenInfoCommand;

        // Свойства класса.
        public string WindowTitle { get; set; }
        public ObservableCollection<Chicken> Chickens { get; set; }
        public Chicken SelectedChicken { get; set; }

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

        public RelayCommand ChickenInfoCommand =>
            _chickenInfoCommand ?? new RelayCommand(obj => new ChickenWindow(SelectedChicken, _farmContext).ShowDialog());

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public CellViewModel() { }

        // Конструктор с параметрами.
        public CellViewModel(Cell cell, FarmContext context)
        {
            _farmContext = context;
            _cell = cell;

            WindowTitle = $"Клетка (ряд {cell.RowNumber}, номер {cell.CellNumber}) ";
            Chickens = new ObservableCollection<Chicken>(cell.Chickens);
        } // ctorf.
        #endregion
    } // CellViewModel.
}
