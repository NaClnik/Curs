using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Requests
{
    // Класс, описывающий запрос.
    public class Request
    {
        // Поля класса.
        private string _command; // Команда.
        private string _action;  // Класс, сериализованный в JSON.

        #region Свойства класса
        // Свойства класса.
        public string Command
        {
            get => _command;
            set => _command = value;
        } // Command.

        public string Action
        {
            get => _action;
            set => _action = value;
        } // SerializedClass.
        #endregion

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public Request() { }

        // Конструктор с параметрами.
        public Request(string command, string action)
        {
            Command = command;
            Action = action;
        } // ctorf.
        #endregion
    } // Request.
}
