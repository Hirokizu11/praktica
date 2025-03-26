using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Nikiforov
{
    class Money
    {
        private int first;  //номинал купюры тенге
        private int second; //количество тенге
        public Money(int nominal, int quantity) //конструктор значения полей, задаём значения полей
        {
            first = nominal;
            second = quantity;
        }
        public int First //задаём свойство для номинала для создания и изменения значения
        {
            get { return first; }
            set { first = value; }
        }
        public int Second //свойство для кол-ва
        {
            get { return second; }
            set { second = value; }
        }
        public int amount //свойство для расчёта суммы
        {
            get { return first * second; }
            set { second = value; }
        }
        public bool canbuy(int price, int quantity) //начало методов
        {
            return amount >= price * quantity;
        }
        public int sumitem(int price) //сумма цены на кол-во товаров
        {
            return amount / price;
        }
        public static Money operator ++(Money obj)
        {
            obj.first++;
            obj.second++;
            return obj;
        }
        public static Money operator --(Money obj)
        {
            obj.first--;
            obj.second--;
            return obj;
        }
        public static bool operator !(Money obj)
        {
            return obj.second != 0;
        }
        public static Money operator +(Money obj, int scalar)
        {
            obj.second += scalar;
            return obj;
        }

        public override string ToString()
        {
            return $"номинал: {first}, кол-во: {second}, сумма: {amount}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номинал купюры:");
            int nominal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество купюр:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Money money = new Money(nominal, quantity);

            Console.WriteLine($"Сумма денег: {money.amount} рублей");

            Console.WriteLine("Введите стоимость одного товара:");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество товаров, которые хотите купить:");
            int tobuy = Convert.ToInt32(Console.ReadLine());

            if (money.canbuy(price, tobuy))
            {
                Console.WriteLine($"Вы можете купить товар или до {money.sumitem(price)} товара(ов) на данную сумму.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для покупки.");
                Console.WriteLine($"Вы можете купить {money.sumitem(price)} товара(ов) на данную сумму..");
            }

            Console.WriteLine(money);

            money++;
            Console.WriteLine("увеличение-" + money);

            money--;
            Console.WriteLine("уменьшение-" + money);

            if (!money)
            {
                Console.WriteLine("кол-во купюр не равно 0");
            }
            else
            {
                Console.WriteLine("кол-во купюр равно 0");
            }

             Money newMoney = money + 5;
            Console.WriteLine("после добавления-" + money);

                Console.ReadLine();
        }
    }
}*/
