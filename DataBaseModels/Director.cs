﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий директора.
    public class Director
    {
        // Свойства класса.
        public int Id { get; set; }
        public virtual Person Person { get; set; }
    } // Director.
}
