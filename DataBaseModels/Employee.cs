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
        public ICollection<Cell> Cells { get; set; } // Клетки, которые обслуживаются работником.
    } // Employee.
}
