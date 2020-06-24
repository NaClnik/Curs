using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels;

namespace DataBaseAccess.Initializers
{
    public class DbInitializer : DropCreateDatabaseAlways<FarmContext>
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
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty"), 
                new PasswordHash("qwerty")
            };

            // Статусы.
            Status[] statuses =
            {
                new Status("Работает"), 
                new Status("Отпуск"), 
                new Status("Уволен")
            };

            // Персоны.
            Person[] persons =
            {
                // Для директора.
                new Person("Картохин", "Алексей", "Павлович", "AE2374", 250000)
                    {Login = logins[0], PasswordHash = passwordHashes[0], Status = statuses[0]}, 

                // Для начальников цехов.
                new Person("Мастерской", "Андрей", "Петрович", "AL5853", 100000)
                    {Login = logins[1], PasswordHash = passwordHashes[1], Status = statuses[0]}, 
                new Person("Лаврухин", "Пётр", "Александрович", "MA5285", 100000)
                    {Login = logins[2], PasswordHash = passwordHashes[2], Status = statuses[0]}, 
                new Person("Макрович", "Абрам", "Нурсултанович", "LP2245", 100000)
                    {Login = logins[3], PasswordHash = passwordHashes[3], Status = statuses[0]},
                
                // Для работников.
                new Person("Секретский", "Алексей", "Олегович", "ZY2856", 80000)
                    {Login = logins[4], PasswordHash = passwordHashes[4], Status = statuses[0]}, 
                new Person("Аргонович", "Семён", "Данилович", "ZZ8643", 50000)
                    {Login = logins[5], PasswordHash = passwordHashes[5], Status = statuses[0]}, 
                new Person("Нурмагомедов", "Гон", "Альбинович", "LM5286", 60000)
                    {Login = logins[6], PasswordHash = passwordHashes[6], Status = statuses[0]}, 
                new Person("Романский", "Роман", "Романович", "MP4912", 60000)
                    {Login = logins[7], PasswordHash = passwordHashes[7], Status = statuses[0]}, 
                new Person("Македонский", "Александр", "Иванович", "KK2992", 60000)
                    {Login = logins[8], PasswordHash = passwordHashes[8], Status = statuses[0]}, 
                new Person("Лаврентьев", "Игорь", "Никитович", "SA9878", 50000)
                    {Login = logins[9], PasswordHash = passwordHashes[9], Status = statuses[0]}
            };

            // Директор.
            Director director = new Director {Person = persons[0]};

            // Начальники цехов.
            Chief[] chiefs =
            {
                new Chief(){Person = persons[1]}, 
                new Chief(){Person = persons[2]}, 
                new Chief(){Person = persons[3]} 
            };

            // Цеха.
            Shop[] shops =
            {
                new Shop(){Chief = chiefs[0]},
                new Shop(){Chief = chiefs[1]},
                new Shop(){Chief = chiefs[2]}
            };

            // Работники.
            Employee[] employees =
            {
                // Работают в 1 цехе.
                new Employee(){Person = persons[4], Shop = shops[0]}, 
                new Employee(){Person = persons[5], Shop = shops[0]}, 

                // Работают во 2 цехе.
                new Employee(){Person = persons[6], Shop = shops[1]}, 
                new Employee(){Person = persons[7], Shop = shops[1]},
                
                // Работают в 3 цехе.
                new Employee(){Person = persons[8], Shop = shops[2]}, 
                new Employee(){Person = persons[9], Shop = shops[2]}
            };

            // Клетки.
            Cell[] cells =
            {
                // Клетки для 1-го цеха.
                new Cell(0, 0){Shop = shops[0], Employee = employees[0]}, 
                new Cell(0, 1){Shop = shops[0], Employee = employees[0]}, 
                new Cell(0, 2){Shop = shops[0], Employee = employees[1]}, 
                new Cell(0, 3){Shop = shops[0], Employee = employees[1]},

                // Клетки для 2-го цеха.
                new Cell(0, 1){Shop = shops[1], Employee = employees[2]}, 
                new Cell(0, 2){Shop = shops[1], Employee = employees[2]}, 
                new Cell(0, 3){Shop = shops[1], Employee = employees[3]}, 
                new Cell(0, 4){Shop = shops[1], Employee = employees[3]},

                // Клетки для 3-го цеха.
                new Cell(0, 1){Shop = shops[2], Employee = employees[4]},
                new Cell(0, 2){Shop = shops[2], Employee = employees[4]},
                new Cell(0, 3){Shop = shops[2], Employee = employees[5]},
                new Cell(0, 4){Shop = shops[2], Employee = employees[5]},
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

            // Заполнение БД.
            context.Diets.Add(new Diet("Диета"));
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
            
            foreach (var item in persons)
                context.Persons.Add(item);
            
            context.Directors.Add(director);
            
            foreach (var item in chiefs)
                context.Chiefs.Add(item);
            
            foreach (var item in shops)
                context.Shops.Add(item);
            
            foreach (var item in employees)
                context.Employees.Add(item);
            
            foreach (var item in cells)
                context.Cells.Add(item);
            
            context.SaveChanges();
        } // Seed.
    } // DbInitializer.
}
