using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ип11
{
    using System;

    public class Genarray<T>
    {
        private T[] array;

        public Genarray(T[] arr)
        {
            array = arr ?? throw new ArgumentNullException(nameof(arr));
        }
        public T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
        public int Length => array.Length;
        public static Genarray<T> operator +(Genarray<T> a, Genarray<T> b)
        {
            T[] newArray = new T[a.Length + b.Length];
            Array.Copy(a.array, 0, newArray, 0, a.Length);
            Array.Copy(b.array, 0, newArray, a.Length, b.Length);

            return new Genarray<T>(newArray);
        }

        public override string ToString()
        {
            return string.Join(", ", array);
        }
    }

    class Program
    {
        static void Main()
        {
            //числа
            var intarray1 = new Genarray<int>(new int[] { 1, 2, 3 });
            var intarray2 = new Genarray<int>(new int[] { 4, 5, 6 });
            var intResult = intarray1 + intarray2;
            Console.WriteLine($"Результат для int: {intResult}");

            //строки
            var strarray1 = new Genarray<string>(new string[] { "a", "b", "c" });
            var strarray2 = new Genarray<string>(new string[] { "d", "e" });
            var stresult = strarray1 + strarray2;
            Console.WriteLine($"Результат для string: {stresult}");
        }
    }
}
