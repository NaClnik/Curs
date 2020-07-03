using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBaseModels;
using Server.Other;

namespace Server.ViewModels
{
    public class ShowTableViewModel
    {
        public ObservableCollection<object> _data;

        private RelayCommand _closeWindowCommand;    // Команда для выхода из приложения.
        private RelayCommand _dragWindowCommand;     // Команда для перетаскивания окна.

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

        public ObservableCollection<object> Data => _data;

        public ShowTableViewModel(ICollection data)
        {
            _data = new ObservableCollection<object>();
            foreach (var item in data)
                _data.Add(item);
        }


    } // ShowTableViewModel.
}
