using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Delegates;
using Client.Views;
using DataBaseAccess;
using DataBaseModels;

namespace Client.Controllers
{
    public class LoginController
    {
        // Поля класса.
        private FarmContext _farmContext;
        private string _login;
        private string _password;
        private Dictionary<string, LoginCommand> _loginCommands;

        // Свойства класса.
        public Dictionary<string, LoginCommand> LoginCommands =>
            _loginCommands ?? new Dictionary<string, LoginCommand>()
            {
                //{"Директор", () => new DirectorWindow(_farmContext, PersonLogin("Директор")).Show()}},
                //{"Директор", () =>  new DirectorWindow(_farmContext, PersonLogin())}
                {"Директор", () =>
                {
                    Person person = PersonLogin("Директор");
                    new DirectorWindow(_farmContext, person).Show();
                    Application.Current.MainWindow?.Close();
                }},
                {"Администратор", () =>
                    {
                        Person person = PersonLogin("Администратор");
                        new AdminWindow(_farmContext).Show();
                        Application.Current.MainWindow?.Close();
                    }
                }
            };

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public LoginController() { }

        // Конструктор с параметрами.
        public LoginController(FarmContext farmContext, string login, string password)
        {
            _farmContext = farmContext;
            _login = login;
            _password = PasswordHash.GetHash(password);
        } // ctorf.

        // Методы класса.
        public Person PersonLogin(string role)
        {
            // Находим в таблице персон всех директоров.
            var directors = _farmContext.Persons.Where(item => item.Role.RoleString == role);
        
            // Находим коллекцию директоров с заданным логином и паролем.
            directors = directors.Where(d =>
                d.Login.LoginString == _login && d.PasswordHash.PasswordHashString == _password);
        
            // Если в коллекции нет ни одного директора, то выбрасываем исключение.
            if (!directors.Any())
                throw new Exception("Вы ввели неверный логин или пароль");
        
            // Т.к. директор у нас должен быть всего один, выбираем его из коллекции.
            return directors.First();
        }
        #endregion
    } // LoginController.
}
