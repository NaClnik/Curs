using System;
using System.Text;

namespace Server.Other
{
    static class Utils
    {
        // Объект для получения случайных чисел.
        public static readonly Random Random = new Random(Environment.TickCount);

        // Получение случайного числа.
        public static int GetRand(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRand(double lo, double hi) => lo + (hi - lo)*Random.NextDouble();

        public static string CreateRegNumber()
        {
            // Создаём массив байт.
            byte[] regNumber = new byte[9];

            // Вспомогательная переменная для того, чтобы постоянно не пересчитывать её в цикле.
            int n = regNumber.Length - 1;

            // Заполняем первые два символа регистрационного номера
            // латинскими символами верхнего регистра.
            for (int i = 0; i < 2; i++)
                regNumber[i] = (byte)GetRand(65, 90);

            // Заполняет паспорт случайными цифрами.
            for (int i = 2; i < n; i++)
                regNumber[i] = (byte)GetRand(48, 57);

            // Возвращает строку регистрационного номера.
            // Обрезаем последний символ, который
            // появляется после перевода из массив байт в строку,
            // который не допустим при чтении из xml.
            // Долго мучался с десериализацией. Решение этой проблемы нашёл здесь:
            // https://stackoverflow.com/questions/968222/invalid-character-x0-encountered
            return Encoding.UTF8.GetString(regNumber).Remove(regNumber.Length - 1);
        } // CreatePassport.
    } // class Utils
}
