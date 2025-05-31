using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic_9
{
    /*#region Задание 1
    public abstract class BaseArray
    {
        protected int[] array;
        public BaseArray(int size) {array = new int[size];}
        public int Size { get {return array.Length;}}
        public abstract void Display();
        public int this[int index]
        {
            get {return array[index];}
            set {array[index] = value;}
        }
    }
    public class DerivedArray : BaseArray
    {
        public DerivedArray(int size) : base(size) { }
        public override void Display()
        {
            Console.WriteLine("Массив:");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();
        }
    }
    class Program1
    {
        static void Main()
        {
            DerivedArray arr = new DerivedArray(5);
            for (int i = 0; i < arr.Size; i++) arr[i] = i * 2;
            arr.Display();
            Console.WriteLine($"Элемент с индексом 2: {arr[2]}");
            Console.ReadLine();
        }
    }
    #endregion
    #region Задание 2
    public abstract class AbstractBase
    {
        protected int field1;
        protected int field2;
        public AbstractBase(int f1, int f2) {field1 = f1; field2 = f2;}
        public abstract int this[int index] {get; set;}
    }
    public interface IInterface
    {
        int Calculate(int multiplier);
    }
    public class CombinedClass : AbstractBase, IInterface
    {
        public CombinedClass(int f1, int f2) : base(f1, f2) { }
        public override int this[int index]
        {
            get {return index % 2 == 0 ? field1 : field2;}
            set {if (index % 2 == 0) field1 = value; else field2 = value;}
        }
        public int Calculate(int multiplier) {return (field1 + field2) * multiplier;}
    }
    class Program2
    {
        static void Main1()
        {
            CombinedClass obj = new CombinedClass(10, 20);
            Console.WriteLine($"При индексе 0: {obj[0]}");
            Console.WriteLine($"При индексе 1: {obj[1]}");
            Console.WriteLine($"Результат метода: {obj.Calculate(3)}");
            Console.ReadLine();
        }
    }
    #endregion
    #region Задание 3
    public abstract class AbstractClass
    {
        public abstract int Property {get; set;}
        public abstract int this[int index] {get; set;}
        public abstract void Method();
    }
    public interface IInterface1
    {
        int Property {get; set;}
        int this[int index] {get; set;}
        void Method();
    }
    public interface IInterface2
    {
        int Property {get; set;}
        int this[int index] {get; set;}
        void Method();
    }
    public class ImplementationClass : AbstractClass, IInterface1, IInterface2
    {
        private int[] data = new int[10];
        int IInterface1.Property {get; set;}
        int IInterface2.Property {get; set;}
        public override int Property {get; set;}
        int IInterface1.this[int index]
        {
            get {return data[index] * 2;}
            set {data[index] = value / 2;}
        }
        int IInterface2.this[int index]
        {
            get {return data[index] * 3;}
            set {data[index] = value / 3;}
        }
        public override int this[int index]
        {
            get {return data[index];}
            set {data[index] = value;}
        }
        void IInterface1.Method() {Console.WriteLine("Метод IInterface1");}
        void IInterface2.Method() {Console.WriteLine("Метод IInterface2");}
        public override void Method() {Console.WriteLine("Метод AbstractClass");}

    }
    class Program3
    {
        static void Main2()
        {
            ImplementationClass obj = new ImplementationClass();
            IInterface1 i1 = obj;
            IInterface2 i2 = obj;
            obj.Property = 10;
            i1.Property = 20;
            i2.Property = 30;
            Console.WriteLine($"Свойства: {obj.Property}, {i1.Property}, {i2.Property}");
            obj[0] = 10;
            i1[1] = 20;
            i2[2] = 30;
            Console.WriteLine($"Индексаторы: {obj[0]}, {i1[1]}, {i2[2]}");
            obj.Method();
            i1.Method();
            i2.Method();
            Console.ReadLine();
        }
    }
    #endregion*/
}
