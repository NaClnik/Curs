using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Requests.Actions
{
    // Класс, который позволит серверу провести авторизацию пользователя.
    public class LoginAction
    {
        // Поля класса.
        private string _login;        // Логин.
        private string _passwordHash; // Хэш пароля.

        #region Свойства класса
        // Свойства класса.
        public string Login
        {
            get => _login;
            set => _login = value;
        } // Login.

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        } // PasswordHash.

        #endregion

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public LoginAction() { }

        // Конструктор с параметрами.
        #endregion

        // Методы класса.
    } // LoginAction.
}
