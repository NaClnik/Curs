using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBaseAccess;
using DataBaseAccess.Initializers;
using DataBaseModels;
using Server.Other;

namespace Server.ViewModels
{
    // ViewModel приложения.
    public class ApplicationViewModel
    {
        // Поля класса.
        private FarmContext _farmContext;
        
        // Свойства класса.
        public FarmContext FarmContext => _farmContext;

        // Поля команд класса.
        private RelayCommand _createDataBaseCommand; // Команда для создания базы данных.

        // Свойства команд класса.
        public RelayCommand CreateDataBaseCommand =>
            _createDataBaseCommand ?? new RelayCommand(obj =>
            {
                //Task.Run(() =>
                //{
                try
                {
                    //using (_farmContext = new FarmContext())
                    //{
                    //    _farmContext.Database.Initialize(false);
                    //    MessageBox.Show("Сделано");
                    //} // using.
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                //});
            });

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.

        // Конструктор с параметрами.
    } // ApplicationViewModel.
}
