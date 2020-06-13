using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    public class Employee
    {
        // Свойства класса.
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Cell> Cells { get; set; } // Клетки, которые обслуживаются работником.
        public virtual Shop Shop { get; set; }               // Цех, за которым закреплён работник.
    } // Employee.
}
