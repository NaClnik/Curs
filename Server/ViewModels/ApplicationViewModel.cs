using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using DataBaseAccess;
using DataBaseAccess.Initializers;
using DataBaseModels;
using Newtonsoft.Json;
using Server.Controllers;
using Server.Other;
using Server.Views;

namespace Server.ViewModels
{
    // ViewModel приложения.
    public class ApplicationViewModel
    {
        // Поля класса.
        private FarmContext _farmContext;
        private ServerController _controller;
        
        // Свойства класса.
        public FarmContext FarmContext => _farmContext;
        public ObservableCollection<PasswordHash> PasswordHashes => _farmContext.PasswordHashes.Local;

        // Поля команд класса.
        private RelayCommand _closeWindowCommand;    // Команда для выхода из приложения.
        private RelayCommand _dragWindowCommand;     // Команда для перетаскивания окна.

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

        public RelayCommand ShowChiefsCommand =>
            _showChiefsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Chiefs.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Chiefs.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowDietsCommand =>
            _showDietsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Diets.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Diets.Local);
                window.ShowDialog();
            });

        public RelayCommand ShowDirectorsCommand =>
            _showDirectorsCommand ?? new RelayCommand(obj =>
            {
                _farmContext.Directors.Load();
                ShowTableWindow window = new ShowTableWindow(_farmContext.Directors.Local);
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
        #endregion

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public ApplicationViewModel()
        {
            try
            {
                Database.SetInitializer(new DbInitializer());
                _farmContext = new FarmContext();
                _farmContext.Database.Initialize(false);
                
                //_farmContext.Directors.Add(new Director
                //{
                //    Person = new Person("sasasa", "sasasa", "sasasa", "sasasa", 2)
                //    {
                //        Status = new Status("Работает"),
                //        Login = new Login("Director"),
                //        PasswordHash = new PasswordHash(PasswordHash.GetHash("Director"))
                //    }
                //});
                //_farmContext.
                //_farmContext.SaveChanges();
                //MessageBox.Show("Сделано");
                //_farmContext.Dispose();
                //Database.SetInitializer(new DbInitializer());
                _controller = new ServerController("127.0.0.1", 999, _farmContext);

                JsonConvert.SerializeObject(_farmContext.Shops.Local, Formatting.Indented,
                    new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
                //Task.Run(_controller.ClientsListening);
                //_controller.ClientsListening();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Методы класса.

    } // ApplicationViewModel.
}
