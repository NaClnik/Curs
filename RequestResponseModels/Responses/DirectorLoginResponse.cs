using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels;

namespace RequestResponseModels.Responses
{
    public class DirectorLoginResponse
    {
        #region Свойства класса
        // Свойства класса.
        public Director Director { get; set; }
        public ObservableCollection<Shop> Shops { get; set; }

        #endregion

        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public DirectorLoginResponse() { }

        // Конструктор с параметрами.
        #endregion
    } // DirectorLoginResponse.
}
