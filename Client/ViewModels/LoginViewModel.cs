using System;
using System.Collections.Generic;
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
using Client.Other;
using Client.Views;
using DataBaseModels;
using Newtonsoft.Json;
using RequestResponseModels.Requests;
using RequestResponseModels.Requests.Actions;
using RequestResponseModels.Responses;

namespace Client.ViewModels
{
    // ViewModel для окна с авторизацией.
    public class LoginViewModel
    {
        // Поля класса.
        private ClientController _controller;
        private string _login;
        private string _role;
        private Dictionary<string, LoginCommand> _loginCommands;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _sendMessgeToServerCommand;

        #region Свойства класса
        // Свойства класса.
        public string Login
        {
            get => _login;
            set => _login = value;
        } // Login.

        public string Role
        {
            get => _role;
            set => _role = value;
        } // Role.

        public Dictionary<string, LoginCommand> LoginCommands =>
            _loginCommands ?? new Dictionary<string, LoginCommand>()
            {
                {
                    "Директор", cmd =>
                    {
                        DirectorLoginResponse response = JsonConvert.DeserializeObject<DirectorLoginResponse>(cmd);

                        DirectorWindow window = new DirectorWindow();

                        MessageBox.Show(response.Director.ToString());

                        //window.Show();
                        //Application.Current.MainWindow.Close();
                    }
                }
            };
        #endregion

        #region Свойства команд класса
        // Свойства команд класса.
        public RelayCommand DragWindowCommand =>
            _dragWindowCommand ?? new RelayCommand(obj => Application.Current.MainWindow.DragMove());

        public RelayCommand SendMessageToServerCommand =>
            _sendMessgeToServerCommand ?? new RelayCommand(obj =>
            {
                // Не делаю привязку к свойству Password, т.к. это сделать нельзя из-за безопасности.
                // Это конечно немного нарушает концепцию MVVM, но мне не приходится хранить
                // пароль в оперативной памяти, что делает безопасность немного лучше.
                // По крайней мере, так советуют здесь: https://stackoverflow.com/questions/1483892/how-to-bind-to-a-passwordbox-in-mvvm
                PasswordBox box = obj as PasswordBox;

                string answer = _controller.LoginDirector(Login, box.Password);
                
                LoginCommands[Role].Invoke(answer);
                //DirectorLoginResponse response = JsonConvert.DeserializeObject<DirectorLoginResponse>(answer);
                //
                //DirectorWindow window = new DirectorWindow();
                //
                //MessageBox.Show(response.Director.ToString());
                //
                //window.Show();
                //Application.Current.MainWindow.Close();

            });
        #endregion

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public LoginViewModel()
        {
            _controller = new ClientController("127.0.0.1", 999);
            Role = "Работник";
        } // ctor.










        //public void SendMessageToServer(string message)
        //{
        //    try
        //    {
        //
        //        var client = new TcpClient("127.0.0.1", 999);
        //
        //        using (NetworkStream stream = client.GetStream())
        //        {
        //            // отправляем сообщение
        //            StreamWriter writer = new StreamWriter(stream);
        //            LoginAction action = new LoginAction() {Login = "Director", PasswordHash = PasswordHash.GetHash("Director")};
        //            Request request = new Request("DirectorLogin", JsonConvert.SerializeObject(action));
        //
        //            writer.WriteLine(JsonConvert.SerializeObject(request));
        //            writer.Flush();
        //
        //            // чтение сообщения от сервера
        //            StreamReader reader = new StreamReader(stream);
        //            string answer = reader.ReadLine();
        //            DirectorLoginResponse response = JsonConvert.DeserializeObject<DirectorLoginResponse>(answer);
        //
        //            MessageBox.Show(response.Director.ToString());
        //
        //            reader.Close();
        //            writer.Close();
        //            client?.Close();
        //        } // using stream
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    } // LoginViewModel.
}
