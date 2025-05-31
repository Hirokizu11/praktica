using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace practic_15
{
    /*class MathAndConvertOperations
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите задание (1-10) или 0 для выхода:");
                Console.WriteLine("1. Вычисление гипотенузы");
                Console.WriteLine("2. Округление чисел");
                Console.WriteLine("3. Тригонометрические функции");
                Console.WriteLine("4. Генератор случайных чисел");
                Console.WriteLine("5. Минимум и максимум в массиве");
                Console.WriteLine("6. Конвертация строки в число");
                Console.WriteLine("7. Преобразование числа в двоичную строку");
                Console.WriteLine("8. Конвертация строки в дату");
                Console.WriteLine("9. Преобразование object в double");
                Console.WriteLine("10. Работа с булевыми значениями");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 10)
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    continue;
                }
                if (choice == 0) break;
                Console.Clear();
                switch (choice)
                {
                    case 1: CalculateHypotenuse(); break;
                    case 2: RoundNumbers(); break;
                    case 3: CalculateTrigonometry(); break;
                    case 4: GenerateRandomNumbers(); break;
                    case 5: FindMinMax(); break;
                    case 6: ConvertStringToInt(); break;
                    case 7: ConvertToBinary(); break;
                    case 8: ConvertStringToDate(); break;
                    case 9: ConvertObjectToDouble(); break;
                    case 10: ConvertToBoolean(); break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #region Математические вычисления (1-5)
        static void CalculateHypotenuse()
        {
            Console.WriteLine("1. Вычисление гипотенузы");
            Console.Write("Введите первый катет: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите второй катет: ");
            double b = double.Parse(Console.ReadLine());
            double hypotenuse = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine($"Гипотенуза: {hypotenuse:F2}");
        }
        static void RoundNumbers()
        {
            Console.WriteLine("2. Округление чисел");
            Console.Write("Введите дробное число: ");
            double num = double.Parse(Console.ReadLine());
            Console.WriteLine($"Math.Floor: {Math.Floor(num)}");
            Console.WriteLine($"Math.Ceiling: {Math.Ceiling(num)}");
            Console.WriteLine($"Math.Round: {Math.Round(num)}");
        }
        static void CalculateTrigonometry()
        {
            Console.WriteLine("3. Тригонометрические функции");
            Console.Write("Введите угол в градусах: ");
            double angle = double.Parse(Console.ReadLine());
            double radians = angle * Math.PI / 180;
            Console.WriteLine($"Синус: {Math.Sin(radians):F4}");
            Console.WriteLine($"Косинус: {Math.Cos(radians):F4}");
            Console.WriteLine($"Тангенс: {Math.Tan(radians):F4}");
        }
        static void GenerateRandomNumbers()
        {
            Console.WriteLine("4. Генератор случайных чисел");
            Random rnd = new Random();
            Console.WriteLine("10 случайных чисел [1-100]:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(rnd.Next(1, 101) + " ");
            }
            Console.WriteLine();
        }
        static void FindMinMax()
        {
            Console.WriteLine("5. Минимум и максимум в массиве");
            double[] numbers = { 3.14, 2.71, 1.62, 4.67, 0.99 };
            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            double min = numbers.Min();
            double max = numbers.Max();
            Console.WriteLine($"Минимум: {min}, Максимум: {max}");
        }
        #endregion
        #region Преобразование типов (6-10)
        static void ConvertStringToInt()
        {
            Console.WriteLine("6. Конвертация строки в число");
            Console.Write("Введите целое число: ");
            string input = Console.ReadLine();
            try
            {
                int number = Convert.ToInt32(input);
                Console.WriteLine($"Успешно преобразовано: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введенная строка не является числом");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: число слишком большое или слишком маленькое");
            }
        }
        static void ConvertToBinary()
        {
            Console.WriteLine("7. Преобразование числа в двоичную строку");
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(number, 2);
            Console.WriteLine($"Двоичное представление: {binary}");
        }
        static void ConvertStringToDate()
        {
            Console.WriteLine("8. Конвертация строки в дату");
            Console.Write("Введите дату (гггг-мм-дд): ");
            string input = Console.ReadLine();
            try
            {
                DateTime date = Convert.ToDateTime(input);
                Console.WriteLine($"Преобразованная дата: {date:dd.MM.yyyy}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат даты");
            }
        }
        static void ConvertObjectToDouble()
        {
            Console.WriteLine("9. Преобразование object в double");
            object[] testValues = { "3.14", 42, null, "abc" };

            foreach (var value in testValues)
            {
                try
                {
                    double result = Convert.ToDouble(value);
                    Console.WriteLine($"Успешно: {value} -> {result}");
                }
                catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
                {
                    Console.WriteLine($"Ошибка: {value} не может быть преобразован в double");
                }
            }
        }
        static void ConvertToBoolean()
        {
            Console.WriteLine("10. Работа с булевыми значениями");
            string[] testValues = { "True", "False", "1", "0", "да", "нет" };

            foreach (var value in testValues)
            {
                try
                {
                    bool result = Convert.ToBoolean(value);
                    Console.WriteLine($"Успешно: {value} -> {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Ошибка: {value} не может быть преобразован в bool");
                }
            }
        }
        #endregion
    }*/
}
