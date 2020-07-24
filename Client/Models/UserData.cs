using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class UserData
    {
        // Поля класса.
        private string _login;
        private string _password;

        #region Свойства класса
        // Свойства класса.
        public string Login
        {
            get => _login;
            set => _login = value;
        } // Login.

        public string Password
        {
            get => _password;
            set => _password = value;
        } // Login.
        #endregion

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public UserData() { }

        // Конструктор с параметрами.
        public UserData(string login, string password)
        {
            Login = login;
            Password = password;
        } // ctorf.
        #endregion
    } // UserData.
}
