using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBaseAccess;
using DataBaseModels;
using Newtonsoft.Json;
using RequestResponseModels.Enums;
using RequestResponseModels.Requests;
using RequestResponseModels.Requests.Actions;
using RequestResponseModels.Responses;
using Server.Delegates;

namespace Server.Controllers
{
    public class ServerController
    {
        // Поля класса.
        private string _ip;                                  // IP-адрес.
        private int _port;                                   // порт для прослушивания подключений
        private Dictionary<string, ServerCommand> _commands; // Словарь с командами.
        private TcpListener _listener;                       // Прослушиватель.
        private static FarmContext _context;                 // БД.

        #region Свойства класса
        // Свойства класса.
        public string Ip
        {
            get => _ip;
            set => _ip = value;
        } // Ip.

        public int Port
        {
            get => _port;
            set
            {
                if (value < 0)
                    throw new Exception("Ошибка! Неправильный порт");

                _port = value;
            } // set.
        } // Port.

        public Dictionary<string, ServerCommand> Commands =>
            _commands ?? new Dictionary<string, ServerCommand>()
            {
                {
                    "DirectorLogin", act =>
                    {
                        LoginAction action = JsonConvert.DeserializeObject<LoginAction>(act);

                        _context.Directors.Load();
                        _context.Shops.Load();

                        Director director = default;
                        foreach (var item in _context.Directors.Local)
                        {
                            if (item.Person.Login.LoginString == action.Login &&
                                item.Person.PasswordHash.PasswordHashString == action.PasswordHash)
                            {

                                director = item;
                                break;
                            }
                        }

                        DirectorLoginResponse response = new DirectorLoginResponse
                        {
                            Director = director, Shops = _context.Shops.Local
                        };

                        Debug.WriteLine(JsonConvert.SerializeObject(director),
                            new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

                        Debug.WriteLine(JsonConvert.SerializeObject(_context.Shops.Local),
                            new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

                        Debug.WriteLine(JsonConvert.SerializeObject(response,
                            new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));

                        return JsonConvert.SerializeObject(response,
                            new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
                    } // Login.

                }
            };
        #endregion

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public ServerController() { }

        public ServerController(string ip, int port, FarmContext context)
        {
            _ip = ip;
            _port = port;
            _context = context;
            _listener = new TcpListener(IPAddress.Parse(ip), Port);
        } // ctorf.

        #endregion

        #region Методы класса
        // Методы класса.
        public void ClientsListening()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    // открытие клиентского подключения
                    using (TcpClient client = _listener.AcceptTcpClient())
                    {
                        // работа с сетевым текстовым потоком
                        using (NetworkStream stream = client.GetStream())
                        {
                            // считываем строку из потока
                            StreamReader reader = new StreamReader(stream);
                            Request request = JsonConvert.DeserializeObject<Request>(reader.ReadLine());

                            string response = Commands[request.Command].Invoke(request.Action);

                            Console.WriteLine($"Запрос получен:\n");
                                              //$"{report}");

                            // отправляем ответ
                            StreamWriter writer = new StreamWriter(stream);
                            writer.WriteLine(response);

                            writer.Close();
                            reader.Close(); // тогда, когда сетевой поток уже не требуется
                        } // stream
                    } // client
                } // while
            } // try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } // catch
            finally
            {
                _listener?.Stop();
            } // finally
        }

        #endregion
    } // ServerController.
}
