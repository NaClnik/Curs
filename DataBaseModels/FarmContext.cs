using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    public class FarmContext : DbContext
    {
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public FarmContext():base("farmContext") { }

        // Таблицы.
        public DbSet<Breed> Breeds { get; set; }       // Таблица "Породы".
        public DbSet<Chicken> Chickens { get; set; }   // Таблица "Курицы".
        public DbSet<Diet> Diets { get; set; }         // Таблица "Диеты".
        public DbSet<Shop> Shops { get; set; }         // Таблица "Цеха".
        public DbSet<Cell> Cells { get; set; }         // Таблица "Клетки".
        public DbSet<Employee> Employees { get; set; } // Таблица "Работники".

        // Настройка таблиц при помощи Fluent API.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
