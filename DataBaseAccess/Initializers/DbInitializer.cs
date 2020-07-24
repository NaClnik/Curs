using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels;

namespace DataBaseAccess.Initializers
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<FarmContext>
    {
        protected override void Seed(FarmContext context)
        {
            // Диеты.
            Diet[] diets =
            {
                new Diet("Стол 1"), 
                new Diet("Стол 2"), 
                new Diet("Стол 3"), 
                new Diet("Стол 4"), 
                new Diet("Стол 5")
            };

            // Породы.
            Breed[] breeds =
            {
                new Breed("Леггорн", 100, 10){Diet = diets[0]},
                new Breed("Хайсек Уайт", 150, 15){Diet = diets[1]},
                new Breed("Хайсек Браун", 160, 7){Diet = diets[2]},
                new Breed("Андалузская голубая", 120, 8){Diet = diets[3]},
                new Breed("Ломан Браун", 110, 12){Diet = diets[4]}
            };

            // Логины.
            Login[] logins =
            {
                new Login("qwerty1"), 
                new Login("qwerty2"), 
                new Login("qwerty3"), 
                new Login("qwerty4"), 
                new Login("qwerty5"), 
                new Login("qwerty6"), 
                new Login("qwerty7"), 
                new Login("qwerty8"), 
                new Login("qwerty9"), 
                new Login("qwerty10")
            };

            // Пароли.
            PasswordHash[] passwordHashes =
            {
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty")), 
                new PasswordHash(PasswordHash.GetHash("qwerty"))
            };

            // Статусы.
            Status[] statuses =
            {
                new Status("Работает"), 
                new Status("Отпуск"), 
                new Status("Уволен")
            };

            // Роли.
            Role[] roles =
            {
                new Role("Директор"),
                new Role("Администратор"), 
                new Role("Работник") 
            };

            // Персоны.
            Person[] persons =
            {
                // Директор.
                new Person("Картохин", "Алексей", "Павлович", "AE2374", 250000)
                    {Login = logins[0], PasswordHash = passwordHashes[0], Status = statuses[0], Role = roles[0]}, 

                // Администратор.
                new Person("Мастерской", "Андрей", "Петрович", "AL5853", 100000)
                    {Login = logins[1], PasswordHash = passwordHashes[1], Status = statuses[0], Role = roles[1]}, 

                // Для работников.
                new Person("Лаврухин", "Пётр", "Александрович", "MA5285", 100000)
                    {Login = logins[2], PasswordHash = passwordHashes[2], Status = statuses[0], Role = roles[0]}, 
                new Person("Макрович", "Абрам", "Нурсултанович", "LP2245", 100000)
                    {Login = logins[3], PasswordHash = passwordHashes[3], Status = statuses[0], Role = roles[0]},
                new Person("Секретский", "Алексей", "Олегович", "ZY2856", 80000)
                    {Login = logins[4], PasswordHash = passwordHashes[4], Status = statuses[0], Role = roles[0]}, 
                new Person("Аргонович", "Семён", "Данилович", "ZZ8643", 50000)
                    {Login = logins[5], PasswordHash = passwordHashes[5], Status = statuses[0], Role = roles[0]}, 
                new Person("Нурмагомедов", "Гон", "Альбинович", "LM5286", 60000)
                    {Login = logins[6], PasswordHash = passwordHashes[6], Status = statuses[0], Role = roles[0]}, 
                new Person("Романский", "Роман", "Романович", "MP4912", 60000)
                    {Login = logins[7], PasswordHash = passwordHashes[7], Status = statuses[0], Role = roles[0]}, 
                new Person("Македонский", "Александр", "Иванович", "KK2992", 60000)
                    {Login = logins[8], PasswordHash = passwordHashes[8], Status = statuses[0], Role = roles[0]}, 
                new Person("Лаврентьев", "Игорь", "Никитович", "SA9878", 50000)
                    {Login = logins[9], PasswordHash = passwordHashes[9], Status = statuses[0], Role = roles[0]}
            };

            // Цеха.
            Shop[] shops =
            {
                new Shop(),
                new Shop(),
                new Shop()
            };

            // Работники.
            Employee[] employees =
            {
                // Работают в 1 цехе.
                new Employee(){Person = persons[2]}, 
                new Employee(){Person = persons[3]}, 
                new Employee(){Person = persons[4]}, 

                // Работают во 2 цехе.
                new Employee(){Person = persons[5]}, 
                new Employee(){Person = persons[6]}, 
                new Employee(){Person = persons[7]},
                
                // Работают в 3 цехе.
                new Employee(){Person = persons[8]}, 
                new Employee(){Person = persons[9]}
            };

            // Клетки.
            Cell[] cells =
            {
                // Клетки для 1-го цеха.
                new Cell(1, 1){Shop = shops[0], Employee = employees[0]}, 
                new Cell(1, 2){Shop = shops[0], Employee = employees[1]}, 
                new Cell(1, 3){Shop = shops[0], Employee = employees[2]}, 
                new Cell(1, 4){Shop = shops[0], Employee = employees[2]},
                new Cell(2, 2){Shop = shops[0], Employee = employees[0]},
                new Cell(2, 3){Shop = shops[0], Employee = employees[1]},

                // Клетки для 2-го цеха.
                new Cell(1, 1){Shop = shops[1], Employee = employees[3]}, 
                new Cell(1, 2){Shop = shops[1], Employee = employees[3]}, 
                new Cell(1, 3){Shop = shops[1], Employee = employees[4]}, 
                new Cell(1, 4){Shop = shops[1], Employee = employees[5]},
                new Cell(2, 3){Shop = shops[1], Employee = employees[3]},
                new Cell(2, 4){Shop = shops[1], Employee = employees[4]},

                // Клетки для 3-го цеха.
                new Cell(1, 1){Shop = shops[2], Employee = employees[6]},
                new Cell(1, 2){Shop = shops[2], Employee = employees[6]},
                new Cell(1, 3){Shop = shops[2], Employee = employees[7]},
                new Cell(1, 4){Shop = shops[2], Employee = employees[7]},
                new Cell(2, 1){Shop = shops[2], Employee = employees[6]},
                new Cell(2, 2){Shop = shops[2], Employee = employees[7]},
            };

            

            // Курицы.
            Chicken[] chickens =
            {
                new Chicken(20, 5, 30){Breed = breeds[0], Cell = cells[0]}, 
                new Chicken(25, 5, 30){Breed = breeds[2], Cell = cells[1]}, 
                new Chicken(21, 5, 30){Breed = breeds[4], Cell = cells[2]}, 
                new Chicken(30, 5, 30){Breed = breeds[0], Cell = cells[3]}, 
                new Chicken(10, 5, 30){Breed = breeds[2], Cell = cells[4]}, 
                new Chicken(56, 5, 30){Breed = breeds[0], Cell = cells[5]}, 
                new Chicken(24, 5, 30){Breed = breeds[1], Cell = cells[6]}, 
                new Chicken(18, 5, 30){Breed = breeds[4], Cell = cells[7]}, 
                new Chicken(15, 5, 30){Breed = breeds[3], Cell = cells[8]}, 
                new Chicken(14, 5, 30){Breed = breeds[4], Cell = cells[9]}, 
                new Chicken(21, 5, 30){Breed = breeds[2], Cell = cells[10]}, 
                new Chicken(4, 5, 30){Breed = breeds[3], Cell = cells[11]}, 
            };

            // Отчёты.
            Report[] reports =
            {
                new Report(10, new DateTime(2020, 5, 9)) {Chicken = chickens[0]},
                new Report(15, new DateTime(2020, 5, 10)){Chicken = chickens[1]},
                new Report(11, new DateTime(2020, 5, 11)){Chicken = chickens[2]},
                new Report(12, new DateTime(2020, 5, 12)){Chicken = chickens[3]},
                new Report(5,  new DateTime(2020, 5, 13)){Chicken = chickens[4]},
                new Report(22, new DateTime(2020, 5, 15)){Chicken = chickens[5]},
                new Report(15, new DateTime(2020, 5, 17)){Chicken = chickens[6]},
                new Report(6,  new DateTime(2020, 5, 19)){Chicken = chickens[7]},
                new Report(2,  new DateTime(2020, 5, 20)){Chicken = chickens[8]},
                new Report(13, new DateTime(2020, 5, 21)){Chicken = chickens[9]},
                new Report(55, new DateTime(2020, 5, 23)){Chicken = chickens[10]},
                new Report(11, new DateTime(2020, 5, 28)){Chicken = chickens[11]},
            };

            // Заполнение БД.
            foreach (var item in diets)
                context.Diets.Add(item);

            foreach (var item in breeds)
                context.Breeds.Add(item);
            
            foreach (var item in logins)
                context.Logins.Add(item);
            
            foreach (var item in passwordHashes)
                context.PasswordHashes.Add(item);
            
            foreach (var item in statuses)
                context.Statuses.Add(item);

            foreach (var item in roles)
                context.Roles.Add(item);

            foreach (var item in persons)
                context.Persons.Add(item);
            
            foreach (var item in shops)
                context.Shops.Add(item);
            
            foreach (var item in employees)
                context.Employees.Add(item);
            
            foreach (var item in cells)
                context.Cells.Add(item);

            foreach (var item in chickens)
                context.Chickens.Add(item);

            foreach (var item in reports)
                context.Reports.Add(item);
            
            context.SaveChanges();
        } // Seed.
    } // DbInitializer.
}
