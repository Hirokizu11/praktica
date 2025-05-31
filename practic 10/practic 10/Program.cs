using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic_10
{
    /*#region Задание 1
    class State
    {
        public decimal Population {get; set;}
        public decimal Area {get; set;}

        public static State operator +(State s1, State s2) =>
            new State {Population = s1.Population + s2.Population, Area = s1.Area + s2.Area};

        public static bool operator >(State s1, State s2) => s1.Population > s2.Population;
        public static bool operator <(State s1, State s2) => s1.Population < s2.Population;
    }
    #endregion
    #region Задание 2
    class Bread
    {
        public int Weight {get; set;}
        public static Sandwich operator +(Bread bread, Butter butter) =>
            new Sandwich {Weight = bread.Weight + butter.Weight};
    }
    class Butter {public int Weight {get; set;}}

    class Sandwich {public int Weight {get; set;}}
    #endregion
    #region Задание 3
    class TextNumber
    {
        public int Number { get; set; }
        public string Text { get; set; }

        public static bool operator >(TextNumber t1, TextNumber t2) => t1.Text.Length > t2.Text.Length;
        public static bool operator <(TextNumber t1, TextNumber t2) => t1.Text.Length < t2.Text.Length;
        public static bool operator >=(TextNumber t1, TextNumber t2) => t1.Number >= t2.Number;
        public static bool operator <=(TextNumber t1, TextNumber t2) => t1.Number <= t2.Number;
        public static bool operator ==(TextNumber t1, TextNumber t2) => t1.Number == t2.Number && t1.Text == t2.Text;
        public static bool operator !=(TextNumber t1, TextNumber t2) => !(t1 == t2);

        public override bool Equals(object obj) => obj is TextNumber tn && this == tn;
        public override int GetHashCode() => HashCode.Combine(Number, Text);
    }
    #endregion
    #region Задание 4
    class LogicalNumber
    {
        public int Value {get; set;}

        public static bool operator true(LogicalNumber ln) => ln.Value is 2 or 3 or 5 or 7;
        public static bool operator false(LogicalNumber ln) => ln.Value < 1 || ln.Value > 10;

        public static LogicalNumber operator &(LogicalNumber ln1, LogicalNumber ln2) =>
            new() {Value = ln1.Value & ln2.Value};

        public static LogicalNumber operator |(LogicalNumber ln1, LogicalNumber ln2) =>
            new() {Value = ln1.Value | ln2.Value};
    }
    #endregion
    #region Задание 5
    class Clock
    {
        public int Hours {get; set;}

        public static implicit operator Clock(int val) => new() { Hours = val % 24 };
        public static explicit operator int(Clock clock) => clock.Hours;
    }
    #endregion

    #region Задание 6
    class Celcius
    {
        public double Gradus {get; set;}
        public static explicit operator Fahrenheit(Celcius c) =>
            new() { Gradus = 9.0 / 5 * c.Gradus + 32 };
    }
    class Fahrenheit
    {
        public double Gradus {get; set;}
        public static explicit operator Celcius(Fahrenheit f) =>
            new() { Gradus = 5.0 / 9 * (f.Gradus - 32) };
    }
    #endregion
    #region Задание 7
    class Dollar
    {
        public decimal Sum {get; set;}
        public static implicit operator Euro(Dollar d) =>
            new() {Sum = d.Sum / 1.14m};
    }
    class Euro
    {
        public decimal Sum {get; set;}
        public static explicit operator Dollar(Euro e) =>
            new() {Sum = e.Sum * 1.14m};
    }
    #endregion
    #region Задание 8
    class TextContainer
    {
        public string Text {get; set;}

        public static explicit operator int(TextContainer tc) => tc.Text.Length;
        public static explicit operator char(TextContainer tc) => tc.Text[0];
        public static implicit operator TextContainer(int num) =>
            new() {Text = new string('А', num)};
    }
    #endregion
    class Program
    {
        static void Main()
        {
            State state1 = new() {Population = 100};
            State state2 = new() {Population = 200};
            Console.WriteLine(state1 > state2); 

            Bread bread = new() { Weight = 80 };
            Butter butter = new() { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight); 

            Clock clock = 34; 
            int hours = (int)clock; 
            Console.WriteLine(hours);

            Celcius c = new() {Gradus = 25};
            Fahrenheit f = (Fahrenheit)c;
            Console.WriteLine(f.Gradus);
        }
    }*/
}