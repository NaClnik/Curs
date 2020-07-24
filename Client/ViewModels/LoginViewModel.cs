using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Client.Controllers;
using Client.Delegates;
using Client.Models;
using Client.Other;
using Client.Views;
using DataBaseAccess;
using DataBaseAccess.Initializers;
using DataBaseModels;
using Newtonsoft.Json;

namespace Client.ViewModels
{
    // ViewModel для окна с авторизацией.
    public class LoginViewModel
    {
        // Поля класса.
        private FarmContext _farmContext;
        private Dictionary<string, LoginCommand> _loginCommands;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _loginCommand;

        #region Свойства класса
        // Свойства класса.
        public string Login { get; set; }
        public string Role { get; set; } = "Работник";

        
        #endregion

        #region Свойства команд класса
        // Свойства команд класса.
        public RelayCommand DragWindowCommand =>
            _dragWindowCommand ?? new RelayCommand(obj => Application.Current.MainWindow.DragMove());

        public RelayCommand LoginCommand => 
            _loginCommand ?? new RelayCommand(obj =>
            {
                var password = (obj as PasswordBox)?.Password;
                new LoginController(_farmContext, Login, password).LoginCommands[Role].Invoke();
            });

        #endregion

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public LoginViewModel()
        {
            Database.SetInitializer(new DbInitializer());
            _farmContext = new FarmContext("farmContext");
            _farmContext.Database.Initialize(false);
        } // ctor.

        // Конструктор с параметрами.
        public LoginViewModel(FarmContext context)
        {
            _farmContext = context;
        } // ctorf.
    } // LoginViewModel.
}
