using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace practic_14
{
    /*class DateTimeTasks
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите задание (1-10) или 0 для выхода:");
                Console.WriteLine("1. Разница между двумя датами");
                Console.WriteLine("2. Определение дня недели");
                Console.WriteLine("3. Добавление дней к дате");
                Console.WriteLine("4. Проверка високосного года");
                Console.WriteLine("5. Форматирование даты и времени");
                Console.WriteLine("6. Сколько дней до Нового года?");
                Console.WriteLine("7. Возраст человека");
                Console.WriteLine("8. Валидация даты");
                Console.WriteLine("9. Часовые пояса");
                Console.WriteLine("10. Таймер обратного отсчёта");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 10)
                {
                    Console.WriteLine("Некорректный ввод.");
                    continue;
                }
                if (choice == 0) break;
                Console.Clear();
                switch (choice)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    case 5: Task5(); break;
                    case 6: Task6(); break;
                    case 7: Task7(); break;
                    case 8: Task8(); break;
                    case 9: Task9(); break;
                    case 10: Task10(); break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #region Задание 1
        static void Task1()
        {
            Console.WriteLine("1. Разница между двумя датами");
            DateTime date1 = ReadDate("Введите первую дату (dd.MM.yyyy HH:mm): ");
            DateTime date2 = ReadDate("Введите вторую дату (dd.MM.yyyy HH:mm): ");
            TimeSpan difference = date2 - date1;
            Console.WriteLine($"\nРазница: {difference.Days} дней, {difference.Hours} часов, {difference.Minutes} минут");
        }
        #endregion
        #region Задание 2
        static void Task2()
        {
            Console.WriteLine("2. Определение дня недели");
            DateTime date = ReadDate("Введите дату (dd.MM.yyyy): ");
            Console.WriteLine($"\nЭто {date.ToString("dddd", new CultureInfo("ru-RU"))}");
        }
        #endregion
        #region Задание 3
        static void Task3()
        {
            Console.WriteLine("3. Добавление дней к дате");
            DateTime date = ReadDate("Введите дату (dd.MM.yyyy): ");
            Console.Write("Введите количество дней для добавления: ");
            int days = int.Parse(Console.ReadLine());
            DateTime newDate = date.AddDays(days);
            Console.WriteLine($"\nНовая дата: {newDate:dd.MM.yyyy}");
        }
        #endregion
        #region Задание 4
        static void Task4()
        {
            Console.WriteLine("4. Проверка високосного года");
            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());
            bool isLeap = DateTime.IsLeapYear(year);
            Console.WriteLine($"\n{year} год {(isLeap ? "високосный" : "не високосный")}");
        }
        #endregion
        #region Задание 5
        static void Task5()
        {
            Console.WriteLine("5. Форматирование даты и времени");
            DateTime date = ReadDate("Введите дату и время (dd.MM.yyyy HH:mm): ");
            Console.WriteLine($"\nФорматы:");
            Console.WriteLine($"dd.MM.yyyy: {date:dd.MM.yyyy}");
            Console.WriteLine($"MM/dd/yyyy: {date:MM/dd/yyyy}");
            Console.WriteLine($"yyyy-MM-dd HH:mm:ss: {date:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"dddd, dd MMMM yyyy: {date.ToString("dddd, dd MMMM yyyy", new CultureInfo("ru-RU"))}");
        }
        #endregion
        #region Задание 6
        static void Task6()
        {
            Console.WriteLine("6. Сколько дней до Нового года?");
            DateTime today = DateTime.Today;
            DateTime newYear = new DateTime(today.Year + 1, 1, 1);
            int daysLeft = (newYear - today).Days;
            Console.WriteLine($"\nДо Нового {newYear.Year} года осталось {daysLeft} дней");
        }
        #endregion
        #region Задание 7
        static void Task7()
        {
            Console.WriteLine("7. Возраст человека");
            DateTime birthDate = ReadDate("Введите дату рождения (dd.MM.yyyy): ");
            DateTime today = DateTime.Today;
            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.Month);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            Console.WriteLine($"\nВозраст: {years} лет, {months} месяцев, {days} дней");
        }
        #endregion
        #region Задание 8
        static void Task8()
        {
            Console.WriteLine("8. Валидация даты");
            Console.Write("Введите дату (dd.MM.yyyy): ");
            string input = Console.ReadLine();
            bool isValid = DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out _);
            Console.WriteLine($"\nДата {(isValid ? "корректна" : "некорректна")}");
        }
        #endregion
        #region Задание 9
        static void Task9()
        {
            Console.WriteLine("9. Часовые пояса");
            DateTime utcNow = DateTime.UtcNow;
            DateTime localNow = DateTime.Now;
            Console.WriteLine($"\nUTC время: {utcNow:HH:mm:ss}");
            Console.WriteLine($"Локальное время: {localNow:HH:mm:ss}");
            Console.WriteLine($"Разница: {TimeZoneInfo.Local.BaseUtcOffset.Hours} часов");
        }
        #endregion
        #region Задание 10
        static void Task10()
        {
            Console.WriteLine("10. Таймер обратного отсчёта");
            Console.Write("Введите количество секунд: ");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine("\nОбратный отсчёт:");
            for (int i = seconds; i >= 0; i--)
            {
                Console.Write($"\rОсталось: {i} сек.");
                if (i > 0) Thread.Sleep(1000);
            }
            Console.WriteLine("\nВремя вышло!");
        }
        #endregion
        #region Вспомогательные методы
        static DateTime ReadDate(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out date))
                    return date;
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out date))
                    return date;
                Console.WriteLine("Некорректный формат даты.)");
            }
        }
        #endregion
    }*/
}
