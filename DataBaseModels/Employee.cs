using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    public class Employee : Person
    {
        // Свойства класса.
        public virtual ICollection<Cell> Cells { get; set; } // Клетки, которые обслуживаются работником.
        public virtual Shop Shop { get; set; }               // Цех, за которым закреплён работник.
    } // Employee.
}
