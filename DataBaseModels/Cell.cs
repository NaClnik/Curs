﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Клетки".
    public class Cell
    {
        // Свойства класса.
        public int Id { get; set; }                                // Идентификатор.
        public CellInfo CellInfo { get; set; }                     // Информация о расположении клетки.
        public virtual Employee Employee { get; set; }             // Работник, закреплённый за клеткой.
        public virtual ICollection<Chicken> Chickens { get; set; } // Куры, находящиеся в клетке.
    } // Shop.
}