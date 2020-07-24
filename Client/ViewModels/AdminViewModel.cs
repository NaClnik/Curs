using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Other;
using Client.Views;
using DataBaseAccess;
using DataBaseModels;
using Newtonsoft.Json;

namespace Client.ViewModels
{
    class AdminViewModel
    {
        // Поля класса.
        private FarmContext _farmContext;


        // Свойства класса.
        public FarmContext FarmContext => _farmContext;
        public ObservableCollection<PasswordHash> PasswordHashes => _farmContext.PasswordHashes.Local;

        // Поля команд класса.
        private RelayCommand _closeWindowCommand;    // Команда для выхода из приложения.
        private RelayCommand _dragWindowCommand;     // Команда для перетаскивания окна.
        private RelayCommand _exitCommand;

        // Поля команд для показа окон с таблицей базы данных.
        private RelayCommand _showBreedsCommand;
        private RelayCommand _showCellsCommand;
        private RelayCommand _showChickensCommand;
        private RelayCommand _showChiefsCommand;
        private RelayCommand _showDietsCommand;
        private RelayCommand _showDirectorsCommand;
        private RelayCommand _showEmployeesCommand;
        private RelayCommand _showLoginsCommand;
        private RelayCommand _showPasswordHashesCommand;
        private RelayCommand _showPersonsCommand;
        private RelayCommand _showShopsCommand;
        private RelayCommand _showStatusesCommand;
        private RelayCommand _showReportsCommand;
        private RelayCommand _showRolesCommand;

        #region Свойства команд класса
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

        public RelayCommand ExitCommand =>
            _exitCommand ?? new RelayCommand(obj =>
            {
                new MainWindow(_farmContext).Show();

                (obj as Window)?.Close();
            });
        #endregion

        #region Свойства команд для показа окон с таблицей базы данных
        // Свойства команд для показа окон с таблицей базы данных.
        public RelayCommand ShowBreedsCommand =>
            _showBreedsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Breeds.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Breeds.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowCellsCommand =>
            _showCellsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Cells.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Cells.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowChickensCommand =>
            _showChickensCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Chickens.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Chickens.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowDietsCommand =>
            _showDietsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Diets.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Diets.Local);
                window.ShowDialog();
            });


        public RelayCommand ShowEmployeesCommand =>
            _showEmployeesCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Employees.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Employees.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowLoginsCommand =>
            _showLoginsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Logins.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Logins.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowPasswordHashesCommand =>
            _showPasswordHashesCommand ?? new RelayCommand(obj =>
            {
                _farmContext.PasswordHashes.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.PasswordHashes.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowPersonsCommand =>
            _showPersonsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Persons.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Persons.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowShopsCommand =>
            _showShopsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Shops.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Shops.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowStatusesCommand =>
            _showStatusesCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Statuses.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Statuses.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowReportsCommand =>
            _showReportsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Reports.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Reports.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowRolesCommand =>
            _showRolesCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Roles.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Roles.Local);
                window.ShowDialog();
            });

        #endregion

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public AdminViewModel() { }

        // Конструктор с параметрами.
        public AdminViewModel(FarmContext context)
        {
            _farmContext = context;
        } // ctorf.
    } // AdminViewModel.
}
