using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic_8
{
    /*#region Задание 1
    public class Animal {public virtual string GetSound() {return "Просто звук";}}
    public class Dog : Animal {public override string GetSound() {return "Гав";}}
    public class Cat : Animal {public override string GetSound() {return "Мяу";}}
    public delegate TResult CovariantDelegate<out TResult>();
    public delegate void ContravariantDelegate<in T>(T arg);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ковариантность:");
            CovariantDelegate<Dog> getDog = () => new Dog();
            CovariantDelegate<Animal> getAnimal = getDog;
            Animal animal = getAnimal();
            Console.WriteLine(animal.GetSound());

            Console.WriteLine("\nКонтравариантность:");
            ContravariantDelegate<Animal> logAnimal = (Animal a) => Console.WriteLine(a.GetSound());
            ContravariantDelegate<Dog> logDog = logAnimal;
            logDog(new Dog());
            Console.ReadLine();
        }
    }
    #endregion
    #region Задание 2
    public interface IAnimalHandler<in TIn, out TOut> where TIn : Animal where TOut : Animal
    {
        TOut Process(TIn animal);
    }
    public class DogHandler : IAnimalHandler<Animal, Dog>
    {
        public Dog Process(Animal animal)
        {
            Console.WriteLine($"Обрабатываем {animal.GetSound()} как собаку");
            return new Dog();
        }
    }
    public class CatHandler : IAnimalHandler<Cat, Animal>
    {
        public Animal Process(Cat cat)
        {
            Console.WriteLine($"Обрабатываем {cat.GetSound()} как животное");
            return new Animal();
        }
    }
    class Zoo
    {
        static void Main1()
        {
            Console.WriteLine("\nОбработка собаки:");
            IAnimalHandler<Animal, Animal> dogHandler = new DogHandler();
            Animal result1 = dogHandler.Process(new Dog());
            Console.WriteLine($"Результат: {result1.GetSound()}");

            Console.WriteLine("\nОбработка кошки:");
            IAnimalHandler<Cat, Animal> catHandler = new CatHandler();
            Animal result2 = catHandler.Process(new Cat());
            Console.WriteLine($"Результат: {result2.GetSound()}");
            Console.ReadLine();
        }
    }
    #endregion*/
}
