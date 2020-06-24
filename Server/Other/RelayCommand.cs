using System;
using System.Windows.Input;

namespace Server.Other
{
    // Ключевым является метод Execute. Для его выполнения в конструкторе команды 
    // передается делегат типа Action<object>. При этом класс команды не знает 
    // какое именно действие будет выполняться.
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // определяет, может ли команда выполняться
        public bool CanExecute(object parameter)
            => canExecute == null || canExecute(parameter);
       

        // собственно выполняет логику команды
        public void Execute(object parameter) => execute(parameter);
       
    } // class RelayCommand
}
