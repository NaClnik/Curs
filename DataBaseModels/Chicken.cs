using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий табилу "Курицы".
    public class Chicken
    {
        // Свойства класса.
        public int Id { get; set; }            // Идентификатор.
        public double Weight { get; set; }     // Вес.
        public int Age { get; set; }           // Возраст.
        public Breed Breed { get; set; }       // Порода.
        public int NumberOfEggs { get; set; }  // Ежемесячное количество яиц.
        // О каждой курице должна храниться следующая информация:
        // вес, возраст, порода, количество ежемесячно получаемых
        // от курицы яиц, а также информация о местонахождении курицы.
    } // Chicken.
}
