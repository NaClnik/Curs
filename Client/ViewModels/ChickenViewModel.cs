using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Other;
using DataBaseAccess;
using DataBaseModels;

namespace Client.ViewModels
{
    class ChickenViewModel
    {
        // Поля класса.
        private Chicken _chicken;
        private FarmContext _farmContext;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _closeWindowCommand;

        // Свойства класса.
        public string WindowTitle { get; set; }
        public ObservableCollection<Report> Reports { get; set; }

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


        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public ChickenViewModel() { }

        // Конструктор с параметрами.
        public ChickenViewModel(Chicken chicken, FarmContext context)
        {
            _farmContext = context;
            _chicken = chicken;

            Reports = new ObservableCollection<Report>(chicken.Reports);
            WindowTitle = $"Курица породы \"{_chicken.Breed.Title}\"";
        } // ctorf.
        #endregion
    } // ChickenViewModel.
}
