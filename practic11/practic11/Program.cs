using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic11
{
    #region Задание 1
    /*public class FootballPlayer
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public FootballPlayer(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
    public class FootballTeam
    {
        private FootballPlayer[] players = new FootballPlayer[11]; //массив из 11 футболистов    
        public FootballPlayer this[int index] //индексатор
        {
            get
            {
                if (index < 0 || index >= 11)
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть от 0 до 10.");
                return players[index];
            }
            set
            {
                if (index < 0 || index >= 11)
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть от 0 до 10.");
                players[index] = value;
            }
        }
        public static void Main()
        {
            FootballTeam team = new FootballTeam();
            team[0] = new FootballPlayer("Игрок 5", 5); //доступ через индексатор
            Console.WriteLine($"Игрок под индексом 0: {team[0].Name}, номер {team[0].Number}");
        }
    }*/
    #endregion
    #region Задание 2
    /*class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }

    class Team
    {
        Player[] players = new Player[11];

        public Player this[int index]
        {
            get
            {
                if (index < 0 || index >= players.Length)
                    throw new ArgumentOutOfRangeException("Индекс должен быть от 0 до 10");
                return players[index];
            }
            set
            {
                if (index < 0 || index >= players.Length)
                    throw new ArgumentOutOfRangeException("Индекс должен быть от 0 до 10");
                players[index] = value;
            }
        }
    }*/
    #endregion
    #region Задание 3
    /*class Word
    {
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }

    class Dictionary
    {
        Word[] words;

        public Dictionary()
        {
            words = new Word[]
            {
            new Word("red", "красный"),
            new Word("blue", "синий"),
            new Word("green", "зеленый")
            };
        }

        public string this[string source]
        {
            get
            {
                foreach (var word in words)
                    if (word.Source == source)
                        return word.Target;
                throw new KeyNotFoundException($"Слово '{source}' не найдено");
            }
            set
            {
                for (int i = 0; i < words.Length; i++)
                    if (words[i].Source == source)
                    {
                        words[i].Target = value;
                        return;
                    }
                throw new KeyNotFoundException($"Слово '{source}' не найдено");
            }
        }
        static void Main()
        {
            Dictionary dict = new Dictionary();
            Console.WriteLine(dict["red"]);
        }
    }*/
    #endregion
    #region Задание 4 
    /*public class CyclicArray
    {
        private int[] _array;
        private int _currentIndex;

        public CyclicArray(int[] array)
        {
            _array = array ?? throw new ArgumentNullException(nameof(array));
            _currentIndex = 0;
        }
        public int CurrentValue
        {
            get
            {
                int value = _array[_currentIndex];
                _currentIndex = (_currentIndex + 1) % _array.Length;
                return value;
            }
            set
    {
                    _array[_currentIndex] = value;
                }
            }
            static void Main()
            {
                int[] numbers = { 10, 20, 30 };
                CyclicArray cycler = new CyclicArray(numbers);

                // Чтение значений
                Console.WriteLine(cycler.CurrentValue);
                Console.WriteLine(cycler.CurrentValue);

                // Запись значения
                cycler.CurrentValue = 99; 

                // Проверка изменений
                Console.WriteLine(cycler.CurrentValue); 
                Console.WriteLine(cycler.CurrentValue); //новый цикл
            }
        }*/
    #endregion
    #region Задание 5
    /*public class DigitNumber
    {
        private int number;

        public DigitNumber(int initialNumber)
        {
            if (initialNumber < 0)
                throw new ArgumentException("Число должно быть неотрицательным");
            number = initialNumber;
        }
        public int Number => number;
        public int this[int index]
        {
            set
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Индекс не может быть отрицательным");
                int newDigit = (value % 10 + 10) % 10;
                int multiplier = (int)Math.Pow(10, index);
                number = number - (GetCurrentDigit(index) * multiplier) + (newDigit * multiplier);
            }
        }
        private int GetCurrentDigit(int index)
        {
            int multiplier = (int)Math.Pow(10, index);
            return (number / multiplier) % 10;
        }
        static void Main()
        {
            DigitNumber num = new DigitNumber(1234);
            Console.WriteLine($"Исходное число: {num.Number}");

            num[1] = 5;    // Меняем десятки (второй разряд) на 5
            Console.WriteLine($"После изменения разряда 1: {num.Number}");

            num[3] = 9;    // Меняем тысячи (четвертый разряд) на 9
            Console.WriteLine($"После изменения разряда 3: {num.Number}");

            num[5] = 3;    // Добавляем сотни тысяч
            Console.WriteLine($"После изменения разряда 5: {num.Number}");
        }
    }*/
    #endregion
    #region Задание 6
    /*public class Fruit
    {
        private string[] fruits = {"apple", "pineapple", "banana"};
        public string this[int index]
        {
            get => fruits[(index % fruits.Length + fruits.Length) % fruits.Length];
            set => fruits[(index % fruits.Length + fruits.Length) % fruits.Length] = value;
        }     
        public char this[int wordIndex, int charIndex]
        {
            get
            {
                string word = this[wordIndex];
                int len = word.Length;
                return word[(charIndex % len + len) % len];
            }
            set
            {
                int wi = (wordIndex % fruits.Length + fruits.Length) % fruits.Length;
                char[] chars = fruits[wi].ToCharArray();
                int ci = (charIndex % chars.Length + chars.Length) % chars.Length;
                chars[ci] = value;
                fruits[wi] = new string(chars);
            }
        }
        static void Main()
        {
            Fruit fruits = new Fruit();
            Console.WriteLine(fruits[3]);
            Console.WriteLine(fruits[2]);
            Console.WriteLine(fruits[1]);

            Console.WriteLine(fruits[-1, -2]);

            fruits[0, 10] = 'X';
            fruits[1, 3] = 'Y';

            Console.WriteLine(fruits[0]);
            Console.WriteLine(fruits[1]);
        }
    }*/
    #endregion
}
