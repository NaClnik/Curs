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
        public int Id { get; set; }              // Идентификатор.
        public double Weight { get; set; }       // Вес.
        public int Age { get; set; }             // Возраст.
        public int NumberOfEggs { get; set; }    // Ежемесячное количество яиц.
        public virtual Breed Breed { get; set; } // Порода.
        public virtual Cell Cell { get; set; }   // Клетка, в которой живёт курица.
    } // Chicken.
}
