using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzevelyukCurs.Models
{
    public class FarmContext : DbContext
    {
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public FarmContext():base("farmContext") { }

        // Таблицы.
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
