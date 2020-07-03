using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Delegates;
using DataBaseModels;
using Newtonsoft.Json;
using RequestResponseModels.Requests;
using RequestResponseModels.Requests.Actions;
using RequestResponseModels.Responses;

namespace Client.Controllers
{
    class ClientController
    {
        // Свойства класса.
        public string Ip { get; set; }
        public int Port { get; set; }


        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public ClientController() { }

        // Конструктор с параметрами.
        public ClientController(string ip, int port)
        {
            Ip = ip;
            Port = port;
        } // ctorf.

        // Методы класса.
        public string LoginDirector(string login, string password)
        {
            var client = new TcpClient(Ip, Port);

            using (NetworkStream stream = client.GetStream())
            {
                // отправляем сообщение
                StreamWriter writer = new StreamWriter(stream);
                LoginAction action = new LoginAction() { Login = login, PasswordHash = PasswordHash.GetHash(password) };
                Request request = new Request("DirectorLogin", JsonConvert.SerializeObject(action));

                writer.WriteLine(JsonConvert.SerializeObject(request));
                writer.Flush();

                // чтение сообщения от сервера
                StreamReader reader = new StreamReader(stream);
                string answer = reader.ReadLine();
                //DirectorLoginResponse response = JsonConvert.DeserializeObject<DirectorLoginResponse>(answer);

                reader.Close();
                writer.Close();
                client?.Close();
                return answer;
            } // using stream
        }
    } // ClientController.
}
