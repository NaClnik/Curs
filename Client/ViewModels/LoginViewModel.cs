using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Other;

namespace Client.ViewModels
{
    // ViewModel для окна с авторизацией.
    public class LoginViewModel
    {
        // Поля команд класса.
        private RelayCommand _dragWindowCommand;

        // Свойства команд класса.
        public RelayCommand DragWindowCommand =>
            _dragWindowCommand ?? new RelayCommand(obj => Application.Current.MainWindow.DragMove());


    } // LoginViewModel.
}
