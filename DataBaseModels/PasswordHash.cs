using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels
{
    // Класс, описывающий таблицу "Хэш Паролей". 
    public class PasswordHash
    {
        // Поля класса.
        private string _passwordHashString;

        // Свойства класса.
        public int Id { get; set; }

        public string PasswordHashString
        {
            get => _passwordHashString;
            set => _passwordHashString = value;
        }
        public virtual ICollection<Person> Persons { get; set; }

        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public PasswordHash() { }

        // Конструктор с параметрами.
        public PasswordHash(string passwordHashString)
        {
            PasswordHashString = passwordHashString;
        } // ctorf.

        public override string ToString() => PasswordHashString;

        // Методы класса.
        public static string GetHash(string value)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));

            return Convert.ToBase64String(hash);
        } // GetHash.
    } // Password.
}
