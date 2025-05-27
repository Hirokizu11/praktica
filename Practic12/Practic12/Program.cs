using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practic12
{
    #region Задание 1
    /*class Program
    {
        static void Main()
        {
            // ArrayList
            Console.WriteLine("=== ArrayList ===");
            ArrayList arrList = new ArrayList();
            arrList.Add(1.1);
            arrList.Add(2.2);
            arrList.Insert(1, 3.3);
            arrList.Remove(2.2);
            Console.WriteLine($"Count: {arrList.Count}, Capacity: {arrList.Capacity}");
            foreach (double num in arrList) Console.WriteLine(num);

            // Queue
            Console.WriteLine("\n=== Queue ===");
            Queue queue = new Queue();
            queue.Enqueue(4.4);
            queue.Enqueue(5.5);
            queue.Enqueue(6.6);
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
            Console.WriteLine($"Next element: {queue.Peek()}");
            Console.WriteLine($"Count: {queue.Count}");
            foreach (double num in queue) Console.WriteLine(num);

            // Hashtable
            Console.WriteLine("\n=== Hashtable ===");
            Hashtable hashTable = new Hashtable();
            hashTable.Add("A", 7.7);
            hashTable["B"] = 8.8;
            hashTable.Remove("A");
            Console.WriteLine($"Count: {hashTable.Count}");
            Console.WriteLine($"Contains key 'B': {hashTable.ContainsKey("B")}");
            foreach (DictionaryEntry entry in hashTable)
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            Console.ReadLine();
        }
    }*/
    #endregion
    #region Задание 1.1
    /*class NegativeValueException : Exception
        {
            public NegativeValueException(string message) : base(message) { }
        }

        class Program
        {
            static void Main()
            {
                // 1. ArrayList
                Console.WriteLine("=== ArrayList ===");
                ArrayList arrList = new ArrayList();
                try
                {
                    arrList.Add(1.1);
                    arrList.Insert(1, 3.3); // Недопустимый индекс (в списке 1 элемент)
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка индекса: {ex.Message}");
                }

                // Пользовательское исключение: отрицательное значение
                try
                {
                    double value = -5.5;
                    if (value < 0) throw new NegativeValueException("Отрицательные значения запрещены!");
                    arrList.Add(value);
                }
                catch (NegativeValueException ex)
                {
                    Console.WriteLine($"Своё исключение: {ex.Message}");
                }

                // 2. Queue
                Console.WriteLine("\n=== Queue ===");
                Queue queue = new Queue();
                queue.Enqueue(4.4);
                queue.Dequeue();

                try
                {
                    queue.Dequeue(); // Попытка извлечь из пустой очереди
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка очереди: {ex.Message}");
                }

                // 3. Hashtable
                Console.WriteLine("\n=== Hashtable ===");
                Hashtable hashTable = new Hashtable();
                hashTable.Add("A", 7.7);

                try
                {
                    hashTable.Add("A", 8.8); // Дубликат ключа
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка хеш-таблицы: {ex.Message}");
                }

                // Вывод результатов
                Console.WriteLine("\nИтоговые данные:");
                Console.WriteLine("ArrayList: " + string.Join(", ", arrList.ToArray()));
                Console.WriteLine("Queue count: " + queue.Count);
                Console.WriteLine("Hashtable: " + string.Join(", ", hashTable.Keys.Cast<string>()));
                Console.ReadLine();
            }
        }*/
    #endregion
    #region Задание 1.2
    /*class Program
    {
        static void ProcessCollection(ref ArrayList list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("Коллекция пуста или не инициализирована.");

            // Вычисляем среднее арифметическое
            double sum = 0;
            foreach (double num in list)
                sum += num;
            double average = sum / list.Count;

            // Обнуляем элементы меньше среднего
            for (int i = 0; i < list.Count; i++)
            {
                if ((double)list[i] < average)
                    list[i] = 0.0;
            }
        }

        static void Main()
        {
            try
            {
                Console.WriteLine("\nОбработка ArrayList:");
                ProcessCollection(ref arrList); // Передача по ссылке с ref
                Console.WriteLine("Элементы после обнуления:");
                foreach (double num in arrList)
                    Console.WriteLine(num);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Ошибка: элемент не является double.");
                Console.ReadLine();
            }
        }
    }*/
    #endregion
    #region Задание 2  
    /*class Program
    {
        static bool IsBracketStructureValid(string input)
        {
            Stack stack = new Stack();

            foreach (char c in input)
            {
                if (c == '(')
                {
                    stack.Push(c); 
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false; 
                    }
                    stack.Pop(); 
                }
                else
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
        static void Main()
        {
            Console.WriteLine("Введите скобочную структуру (только круглые скобки):");
            string input = Console.ReadLine();
            if (IsBracketStructureValid(input))
            {
                Console.WriteLine("Правильная структура!");
            }
            else
            {
                Console.WriteLine("Неправильная структура!");
                Console.ReadLine();
            }
        }
    }*/
    #endregion
    #region Задание 3
    /*class Student
    {
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public int Course {get; set;}
        public int MathScore {get; set;}
        public int PhysicsScore {get; set;}
        public int InformaticsScore {get; set;}

        public double AverageScore =>
            (MathScore + PhysicsScore + InformaticsScore) / 3.0;
    }
    class Program
    {
        static void Main()
        {           
            Student[] studentsArray = {
            new Student { LastName = "Иванов", FirstName = "Иван", Course = 1, MathScore = 3, PhysicsScore = 4, InformaticsScore = 5 },
            new Student { LastName = "Петров", FirstName = "Пётр", Course = 2, MathScore = 2, PhysicsScore = 3, InformaticsScore = 2 },
            new Student { LastName = "Сидоров", FirstName = "Алексей", Course = 2, MathScore = 4, PhysicsScore = 4, InformaticsScore = 4 },
            new Student { LastName = "Смирнова", FirstName = "Мария", Course = 3, MathScore = 5, PhysicsScore = 5, InformaticsScore = 5 },
            new Student { LastName = "Кузнецов", FirstName = "Дмитрий", Course = 2, MathScore = 3, PhysicsScore = 3, InformaticsScore = 2 },
            new Student { LastName = "Васильев", FirstName = "Андрей", Course = 4, MathScore = 4, PhysicsScore = 3, InformaticsScore = 4 }
        };
            FindWorstStudent(studentsArray, "Массив");         
            Queue<Student> studentsQueue = new Queue<Student>();
            foreach (var student in studentsArray)
            {
                studentsQueue.Enqueue(student);
            }
            FindWorstStudent(studentsQueue, "Очередь");
        }
        static void FindWorstStudent(IEnumerable<Student> students, string collectionType)
        {
            Student worstStudent = null;
            double minAverage = double.MaxValue;

            foreach (var student in students)
            {
                if (student.Course == 2 && student.AverageScore < minAverage)
                {
                    minAverage = student.AverageScore;
                    worstStudent = student;
                }
            }
            Console.WriteLine($"\nРезультат ({collectionType}):");
            if (worstStudent != null)
            {
                Console.WriteLine($"Худший студент 2 курса: {worstStudent.LastName} {worstStudent.FirstName}, " +
                                  $"Средний балл: {worstStudent.AverageScore:F2}");
            }
            else
            {
                Console.WriteLine("Студентов 2 курса не найдено!");
                Console.ReadLine();
            }
        }
    }*/
    #endregion
    #region Задание 4
    /*public class Transport
    {
        public string Name {get; set;}
        public int MaxSpeed {get; set;}
    }
    public class Car : Transport
    {
        public int Wheels {get; set;}
        public Transport BaseTransport
        {
            get => new Transport {Name = this.Name, MaxSpeed = this.MaxSpeed};
        }
    }
public class TestCollections<TKey, TValue> where TKey : Transport where TValue : Car
    {
        public List<TKey> Collection1 { get; set; }
        public List<string> Collection1String { get; set; }
        public Dictionary<TKey, TValue> Collection2 { get; set; }
        public Dictionary<string, TValue> Collection2String { get; set; }
        public TestCollections()
        {
            Collection1 = new List<TKey>();
            Collection1String = new List<string>();
            Collection2 = new Dictionary<TKey, TValue>();
            Collection2String = new Dictionary<string, TValue>();
        }
    }
    class Program
    {
        static void Main()
        {
            var car = new Car { Name = "Tesla", MaxSpeed = 250, Wheels = 4 };
            Transport baseTransport = car.BaseTransport;
            var test = new TestCollections<Transport, Car>();
            test.Collection1.Add(baseTransport);
            test.Collection1String.Add("Fast Car");
            test.Collection2.Add(baseTransport, car);
            test.Collection2String.Add("Model S", car);
            Console.WriteLine("Collection1 (Transport):");
            foreach (var item in test.Collection1)
                Console.WriteLine($"{item.Name} - {item.MaxSpeed} км/ч");

            Console.WriteLine("\nCollection2 (Transport -> Car):");
            foreach (var pair in test.Collection2)
                Console.WriteLine($"{pair.Key.Name} -> {pair.Value.Wheels} колес");
            Console.ReadLine();
        }
    }*/
    #endregion
    #region Задание 5
    /*public class Person
    {
        public string Name {get; set;}
        public int Age {get; set;}
    }
    public class Student : Person
    {
        public int StudentId { get; set; }
        public Person BasePerson => new Person
        {
            Name = this.Name,
            Age = this.Age
        };
    }
    public class TestCollections<TKey, TValue>
        where TKey : Person
        where TValue : Student
    {
        public List<TKey> Collection1 {get;}          
        public List<string> Collection1String {get;}  
        public Dictionary<TKey, TValue> Collection2 {get;}       
        public Dictionary<string, TValue> Collection2String {get;} 
        public TestCollections(int count)
        {
            Collection1 = new List<TKey>();
            Collection1String = new List<string>();
            Collection2 = new Dictionary<TKey, TValue>();
            Collection2String = new Dictionary<string, TValue>();
            for (int i = 0; i < count; i++)
            {
                var student = GenerateStudent(i) as TValue;
                var person = student.BasePerson as TKey;
                Collection1.Add(person);
                Collection1String.Add($"Person_{i}");
                Collection2.Add(person, student);
                Collection2String.Add($"Key_{i}", student);
            }
        }
        private Student GenerateStudent(int index)
        {
            return new Student
            {
                Name = $"Student_{index}",
                Age = 18 + index % 5,
                StudentId = 1000 + index
            };
        }
    }
    class Program
    {
        static void Main()
        {
            var test = new TestCollections<Person, Student>(5);

            Console.WriteLine("Collection1 (Person):");
            foreach (var person in test.Collection1)
                Console.WriteLine($"{person.Name} ({person.Age} лет)");

            Console.WriteLine("\nCollection2 (Person -> Student):");
            foreach (var pair in test.Collection2)
                Console.WriteLine($"{pair.Key.Name} -> ID: {pair.Value.StudentId}");
            Console.ReadLine();
        }
    }*/
    #endregion
    #region  Задание 5.1
    /*public class Person
    {
        public string Name {get; set;}
        public int Age {get; set;}
    }
    public class Student : Person
    {
        public int StudentId { get; set; }
        public Person PersonData => new Person
        {
            Name = this.Name,
            Age = this.Age
        };
    }
    public class TestCollections<TKey, TValue>
        where TKey : Person
        where TValue : Student
    {
        public List<TKey> PersonList {get;}       
        public List<string> StringKeys {get;}    
        public Dictionary<TKey, TValue> PersonStudentDict {get;} 
        public Dictionary<string, TValue> StringStudentDict {get;} 
        public TestCollections(int count)
        {
            PersonList = new List<TKey>();
            StringKeys = new List<string>();
            PersonStudentDict = new Dictionary<TKey, TValue>();
            StringStudentDict = new Dictionary<string, TValue>();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                TValue student = GenerateStudent(i) as TValue;
                TKey person = student.PersonData as TKey;
                PersonList.Add(person);
                StringKeys.Add($"Key_{i}");
                PersonStudentDict.Add(person, student);
                StringStudentDict.Add($"StrKey_{i}", student);
            }
        }
        private Student GenerateStudent(int id)
        {
            return new Student
            {
                Name = $"Student_{id}",
                Age = 18 + id % 5,
                StudentId = id
            };
        }
    }
    class Program
    {
        static void Main()
        {
            var test = new TestCollections<Person, Student>(5);

            Console.WriteLine("Список Person (базовый класс):");
            foreach (var person in test.PersonList)
                Console.WriteLine($"{person.Name}, возраст: {person.Age}");

            Console.WriteLine("\nСловарь Person-Student:");
            foreach (var pair in test.PersonStudentDict)
                Console.WriteLine($"{pair.Key.Name} -> ID: {pair.Value.StudentId}");
            Console.ReadLine();
        }
    }*/
    #endregion
    #region Задание 6
    /*public class Person
    {
        public string Name {get; set;}
        public int Age {get; set;}

        public override string ToString() => $"{Name}_{Age}";
    }
    public class Student : Person
    {
        public int StudentId {get; set;}

        public Person BasePerson => new Person
        {
            Name = this.Name,
            Age = this.Age
        };
    }
    public class TestCollections<TKey, TValue>
        where TKey : Person
        where TValue : Student
    {
        public List<TKey> Collection1 { get; } = new List<TKey>();
        public List<string> Collection1String { get; } = new List<string>();
        public Dictionary<TKey, TValue> Collection2 { get; } = new Dictionary<TKey, TValue>();
        public Dictionary<string, TValue> Collection2String { get; } = new Dictionary<string, TValue>();
        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                TValue student = GenerateStudent(i) as TValue;
                TKey personKey = student.BasePerson as TKey;
                string stringKey = personKey.ToString();
                Collection1.Add(personKey);
                Collection1String.Add(stringKey);
                Collection2.Add(personKey, student);
                Collection2String.Add(stringKey, student);
            }
        }
        private Student GenerateStudent(int id)
        {
            return new Student
            {
                Name = $"Student_{id}",
                Age = 18 + id % 5,
                StudentId = id
            };
        }
    }
    class Program
    {
        static void Main()
        {
            var test = new TestCollections<Person, Student>(5);

            Console.WriteLine("Проверка соот-вий:");
            Console.WriteLine($"Количество элементов: {test.Collection1.Count}");
            for (int i = 0; i < test.Collection1.Count; i++)
            {
                var personKey = test.Collection1[i];
                var stringKey = test.Collection1String[i];
                Console.WriteLine($"\nЭлемент {i + 1}:");
                Console.WriteLine($"Collection1: {personKey.Name} ({personKey.Age})");
                Console.WriteLine($"Collection1String: {stringKey}");
                Console.WriteLine($"Collection2 содержит ключ: {test.Collection2.ContainsKey(personKey)}");
                Console.WriteLine($"Collection2String содержит ключ: {test.Collection2String.ContainsKey(stringKey)}");
                Console.ReadLine();
            }
        }
    }*/
    #endregion
    #region Задание 7
    /*public class Person
    {
        public string Name {get; set;}
        public int Age {get; set;}
        public override bool Equals(object obj) =>
            obj is Person p && p.Name == Name && p.Age == Age;
        public override int GetHashCode() => HashCode.Combine(Name, Age);

        public override string ToString() => $"{Name}_{Age}";
    }
    public class Student : Person
    {
        public int StudentId { get; set; }

        public Person BasePerson => new Person
        {
            Name = this.Name,
            Age = this.Age
        };
    }
    public class TestCollections<TKey, TValue> where TKey : Person where TValue : Student
    {
        public List<TKey> Collection1 { get; } = new List<TKey>();
        public List<string> Collection1String {get;} = new List<string>();
        public Dictionary<TKey, TValue> Collection2 {get;} = new Dictionary<TKey, TValue>();
        public Dictionary<string, TValue> Collection2String {get;} = new Dictionary<string, TValue>();
        public TKey FirstKey {get; private set;}
        public TKey MiddleKey {get; private set;}
        public TKey LastKey {get; private set;}
        public TKey NotExistKey {get; private set;}
        public TValue FirstValue {get; private set;}
        public TValue MiddleValue {get; private set;}
        public TValue LastValue {get; private set;}
        public TValue NotExistValue {get; private set;}
        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var student = GenerateStudent(i) as TValue;
                var person = student.BasePerson as TKey;
                var stringKey = person.ToString();

                Collection1.Add(person);
                Collection1String.Add(stringKey);
                Collection2.Add(person, student);
                Collection2String.Add(stringKey, student);
            }
            int middleIndex = count / 2;
            FirstKey = Collection1[0];
            MiddleKey = Collection1[middleIndex];
            LastKey = Collection1[^1];
            NotExistKey = new Person { Name = "NotExist", Age = -1 } as TKey;

            FirstValue = Collection2[FirstKey];
            MiddleValue = Collection2[MiddleKey];
            LastValue = Collection2[LastKey];
            NotExistValue = GenerateStudent(count + 100) as TValue;
        }
        public void MeasureSearchTime()
        {
            var testKeys = new[] { FirstKey, MiddleKey, LastKey, NotExistKey };
            var testStringKeys = new[] {
            FirstKey.ToString(),
            MiddleKey.ToString(),
            LastKey.ToString(),
            "NotExist_Key"
        };
            Console.WriteLine("\n=== Время поиска ===");

            foreach (var key in testKeys)
            {
                Measure(() => Collection1.Contains(key),
                       $"List<TKey>.Contains({key})");
            }

            foreach (var key in testStringKeys)
            {
                Measure(() => Collection1String.Contains(key),
                       $"List<string>.Contains({key})");
            }

            foreach (var key in testKeys)
            {
                Measure(() => Collection2.ContainsKey(key),
                       $"Dict<TKey,TVal>.ContainsKey({key})");
            }

            foreach (var key in testStringKeys)
            {
                Measure(() => Collection2String.ContainsKey(key),
                       $"Dict<string,TVal>.ContainsKey({key})");
            }

            var testValues = new[] { FirstValue, MiddleValue, LastValue, NotExistValue };
            foreach (var val in testValues)
            {
                Measure(() => Collection2.ContainsValue(val),
                       $"Dict<TKey,TVal>.ContainsValue({val.StudentId})");
            }
        }
        private Student GenerateStudent(int id) => new Student
        {
            Name = $"Student_{id}",
            Age = 18 + id % 5,
            StudentId = id
        };
        private void Measure(Action action, string operation)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            Console.WriteLine($"{operation,-40} {sw.ElapsedTicks} тиков");
        }
    }
    class Program
    {
        static void Main()
        {
            var test = new TestCollections<Person, Student>(1000);
            test.MeasureSearchTime();
    Console.ReadLine();
        }
    }*/
    #endregion
}