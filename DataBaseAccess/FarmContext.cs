using System.Data.Entity;
using DataBaseModels;

namespace DataBaseAccess
{
    public class FarmContext : DbContext
    {
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public FarmContext() { }

        // Конструктор с параметрами.
        public FarmContext(string nameOrConnectionString):base(nameOrConnectionString) { }

        // Таблицы.
        public DbSet<Breed> Breeds { get; set; }                // Таблица "Породы".
        public DbSet<Chicken> Chickens { get; set; }            // Таблица "Курицы".
        public DbSet<Diet> Diets { get; set; }                  // Таблица "Диеты".
        public DbSet<Shop> Shops { get; set; }                  // Таблица "Цеха".
        public DbSet<Cell> Cells { get; set; }                  // Таблица "Клетки".
        public DbSet<Login> Logins { get; set; }                // Таблица "Логины".
        public DbSet<PasswordHash> PasswordHashes { get; set; } // Таблица "Хэши паролей".
        public DbSet<Status> Statuses { get; set; }             // Таблица "Статусы".
        public DbSet<Person> Persons { get; set; }              // Таблица "Персоны".
        public DbSet<Director> Directors { get; set; }          // Таблица "Директора".
        public DbSet<Chief> Chiefs { get; set; }                // Таблица "Начальники".
        public DbSet<Employee> Employees { get; set; }          // Таблица "Работники".

        // Настройка таблиц при помощи Fluent API.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Связи один-ко-многим
            // Связи один-ко-многим.
            modelBuilder.Entity<Breed>()
                .HasMany(p => p.Chickens)
                .WithRequired(p => p.Breed);

            modelBuilder.Entity<Diet>()
                .HasMany(p => p.Breeds)
                .WithRequired(p => p.Diet);

            modelBuilder.Entity<Cell>()
                .HasMany(p => p.Chickens)
                .WithRequired(p => p.Cell);

            modelBuilder.Entity<Employee>()
                .HasMany(p => p.Cells)
                .WithRequired(p => p.Employee);

            modelBuilder.Entity<Login>()
                .HasMany(p => p.Persons)
                .WithRequired(p => p.Login);

            modelBuilder.Entity<PasswordHash>()
                .HasMany(p => p.Persons)
                .WithRequired(p => p.PasswordHash);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Directors)
                .WithRequired(p => p.Person);
            
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Chiefs)
                .WithRequired(p => p.Person);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Employees)
                .WithRequired(p => p.Person);

            modelBuilder.Entity<Shop>()
                .HasMany(p => p.Cells)
                .WithRequired(p => p.Shop);

            modelBuilder.Entity<Shop>()
                .HasMany(p => p.Employees)
                .WithRequired(p => p.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(p => p.Persons)
                .WithRequired(p => p.Status);


            #endregion


            #region Связи один-к-одному
            // Связи один-к-одному.
            modelBuilder.Entity<Chief>()
                .HasRequired(c => c.Shop)
                .WithRequiredPrincipal(c => c.Chief);

            #endregion

            #region Настройка Breed
            // Настройка Breed.
            modelBuilder.Entity<Breed>()
                .Property(p => p.Title)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Breed>()
                .Property(p => p.Performance)
                .IsRequired();

            modelBuilder.Entity<Breed>()
                .Property(p => p.AverageWeight)
                .IsRequired();
            #endregion

            #region Настройка Cell
            // Настройка Cell.
            modelBuilder.Entity<Cell>()
                .Property(p => p.RowNumber)
                .IsRequired();

            modelBuilder.Entity<Cell>()
                .Property(p => p.CellNumber)
                .IsRequired();
            #endregion

            #region Настройка Chicken 
            // Настройка Chicken.
            modelBuilder.Entity<Chicken>()
                .Property(p => p.Weight)
                .IsRequired();

            modelBuilder.Entity<Chicken>()
                .Property(p => p.Age)
                .IsRequired();

            modelBuilder.Entity<Chicken>()
                .Property(p => p.NumberOfEggs)
                .IsRequired();
            #endregion

            #region Настройка Diet
            // Настройка Diet.
            modelBuilder.Entity<Diet>()
                .Property(p => p.DietTitle)
                .IsRequired()
                .IsUnicode();
            #endregion

            #region Настройка PasswordHash
            // Настройка PasswordHash.
            modelBuilder.Entity<PasswordHash>()
                .Property(p => p.PasswordHashString)
                .IsRequired()
                .IsUnicode();
            #endregion

            #region Настройка Person
            // Настройка Person.
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Person>()
                .Property(p => p.Surname)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Person>()
                .Property(p => p.Patronymic)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Person>()
                .Property(p => p.Passport)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Person>()
                .Property(p => p.Salary)
                .IsRequired();
            #endregion

            #region Настройка Status
            // Настройка Status.
            modelBuilder.Entity<Status>()
                .Property(p => p.StatusString)
                .IsRequired()
                .IsUnicode();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
