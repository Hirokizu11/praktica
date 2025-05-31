using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace practic_16
{
    /*class PatternTasks
    {
        #region Вспомогательные классы
        public class Person
        {
            public string Name {get; set;}
            public int Age {get; set;}
        }
        public record Point(int X, int Y);
        public class Shape { }
        public class Circle : Shape {public double Radius {get; set;}}
        public class Rectangle : Shape {public double Width {get; set;} public double Height {get; set;}}
        #endregion
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите задание (1-10) или 0 для выхода:");
                for (int i = 1; i <= 10; i++)
                    Console.WriteLine($"{i}. {GetTaskTitle(i)}");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 10)
                {
                    Console.WriteLine("Некорректный ввод");
                    continue;
                }
                if (choice == 0) break;
                Console.Clear();
                ExecuteTask(choice);
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static string GetTaskTitle(int taskNumber) => taskNumber switch
        {
            1 => "Простой паттерн по типу",
            2 => "Проверка на null",
            3 => "Паттерн свойств (Person)",
            4 => "Паттерн кортежей",
            5 => "Позиционный паттерн (Point)",
            6 => "Паттерн с when (четность)",
            7 => "Паттерн с switch expression",
            8 => "Паттерн с логическими операторами",
            9 => "Рекурсивные паттерны (Shape)",
            10 => "Паттерн в цикле и коллекциях",
            _ => "Неизвестное задание"
        };
        static void ExecuteTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case 1:
                    Console.WriteLine(GetTypePattern("строка"));
                    Console.WriteLine(GetTypePattern(42));
                    Console.WriteLine(GetTypePattern(true));
                    Console.WriteLine(GetTypePattern(3.14));
                    break;
                case 2:
                    Console.WriteLine(CheckNull(null));
                    Console.WriteLine(CheckNull("текст"));
                    Console.WriteLine(CheckNull(123));
                    break;
                case 3:
                    Console.WriteLine(GetPersonCategory(new Person { Age = 10 }));
                    Console.WriteLine(GetPersonCategory(new Person { Age = 30 }));
                    Console.WriteLine(GetPersonCategory(new Person { Age = 65 }));
                    Console.WriteLine(GetPersonCategory(null));
                    break;
                case 4:
                    Console.WriteLine(CheckCoordinates((1, 2)));
                    Console.WriteLine(CheckCoordinates((-1, -2)));
                    Console.WriteLine(CheckCoordinates((1, -2)));
                    break;
                case 5:
                    Console.WriteLine(DescribePoint(new Point(0, 0)));
                    Console.WriteLine(DescribePoint(new Point(5, 0)));
                    Console.WriteLine(DescribePoint(new Point(0, 5)));
                    Console.WriteLine(DescribePoint(new Point(5, 5)));
                    Console.WriteLine(DescribePoint(new Point(-5, -5)));
                    break;
                case 6:
                    Console.WriteLine(CheckEvenOdd(4));
                    Console.WriteLine(CheckEvenOdd(7));
                    Console.WriteLine(CheckEvenOdd("текст"));
                    break;
                case 7:
                    Console.WriteLine(GetTrafficLightAction("Red"));
                    Console.WriteLine(GetTrafficLightAction("Yellow"));
                    Console.WriteLine(GetTrafficLightAction("Green"));
                    Console.WriteLine(GetTrafficLightAction("Blue"));
                    break;
                case 8:
                    Console.WriteLine(CategorizeNumber(5));
                    Console.WriteLine(CategorizeNumber(15));
                    Console.WriteLine(CategorizeNumber(0));
                    Console.WriteLine(CategorizeNumber(25));
                    break;
                case 9:
                    Console.WriteLine(CalculateArea(new Circle { Radius = 5 }));
                    Console.WriteLine(CalculateArea(new Rectangle { Width = 4, Height = 6 }));
                    Console.WriteLine(CalculateArea(new Shape()));
                    break;
                case 10:
                    object[] items = { 1, "two", 3.0, null, true, new Person() };
                    foreach (var item in items)
                        Console.WriteLine(GetTypePattern(item));
                    break;
            }
        }
        #region Реализация заданий
        static string GetTypePattern(object obj) => obj switch
        {
            string s => $"Это строка: {s}",
            int i => $"Это число: {i}",
            bool b => $"Это булево значение: {b}",
            _ => "Неизвестный тип"
        };
        static string CheckNull(object? obj) => obj switch
        {
            null => "Объект null",
            _ => $"Не null: {obj.GetType().Name}"
        };
        static string GetPersonCategory(Person? person) => person switch
        {
            { Age: < 18 } => "Ребенок",
            { Age: >= 18 and < 60 } => "Взрослый",
            { Age: >= 60 } => "Пенсионер",
            null => "Неизвестно",
            _ => "Неизвестно"
        };
        static string CheckCoordinates((int x, int y) coords) => coords switch
        {
            ( > 0, > 0) => "Обе координаты положительные",
            ( < 0, < 0) => "Обе координаты отрицательные",
            _ => "Координаты в разных квадрантах"
        };
        static string DescribePoint(Point point) => point switch
        {
            (0, 0) => "Начало координат",
            (_, 0) => "На оси X",
            (0, _) => "На оси Y",
            ( > 0, > 0) => "В квадранте I",
            ( < 0, > 0) => "В квадранте II",
            ( < 0, < 0) => "В квадранте III",
            ( > 0, < 0) => "В квадранте IV"
        };
        static string CheckEvenOdd(object obj) => obj switch
        {
            int i when i % 2 == 0 => $"Четное число: {i}",
            int i => $"Нечетное число: {i}",
            _ => "Не число"
        };
        static string GetTrafficLightAction(string color) => color switch
        {
            "Red" => "Stop",
            "Yellow" => "Wait",
            "Green" => "Go",
            _ => "Unknown"
        };
        static string CategorizeNumber(int number) => number switch
        {
            >= 1 and <= 10 => "От 1 до 10",
            >= 11 and <= 20 => "От 11 до 20",
            <= 0 => "0 или отрицательное",
            _ => "Больше 20"
        };
        static double CalculateArea(Shape shape) => shape switch
        {
            Circle { Radius: var r } => Math.PI * r * r,
            Rectangle { Width: var w, Height: var h } => w * h,
            _ => 0
        };
        #endregion
    }*/
}
