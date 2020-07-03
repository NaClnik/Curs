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
        public virtual Shop Shop { get; set; }               // Цех, за которым закреплён работник.
        public virtual ICollection<Cell> Cells { get; set; } // Клетки, которые обслуживаются работником.

        public override string ToString() => Person.ToString();
    } // Employee.
}
