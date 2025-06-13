using System;
using System.Collections.Generic;
namespace SuperPractic
{
    //Strategy 
    public interface ICommissionStrategy
    {
        decimal CalculateCommission(decimal amount);
    }
    public class FixedCommission : ICommissionStrategy
    {
        private readonly decimal _fixedAmount;
        public FixedCommission(decimal fixedAmount) => _fixedAmount = fixedAmount;
        public decimal CalculateCommission(decimal amount) => _fixedAmount;
    }
    public class PercentageCommission : ICommissionStrategy
    {
        private readonly decimal _percentage;
        public PercentageCommission(decimal percentage) => _percentage = percentage;
        public decimal CalculateCommission(decimal amount) => amount * _percentage / 100;
    }
    //Command 
    public interface ITransactionCommand
    {
        void Execute();
        void Undo();
    }
    //Observer 
    public interface ITransactionObserver
    {
        void Update(string eventType, Transaction transaction);
    }
    //Decorator 
    public abstract class TransactionProcessorDecorator : ITransactionProcessor
    {
        protected readonly ITransactionProcessor _processor;
        public TransactionProcessorDecorator(ITransactionProcessor processor) => _processor = processor;
        public abstract void ProcessTransaction(Transaction transaction);
    }
    //Singleton 
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger() { }
        public static Logger Instance => _instance;
        public void Log(string message) => Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
    //компоненты
    public enum TransactionType { Payment, Transfer, Deposit }
    public enum TransactionStatus { Pending, Completed, Cancelled }
    public class Transaction
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;
        public decimal Commission { get; set; }
    }
    public interface ITransactionProcessor
    {
        void ProcessTransaction(Transaction transaction);
    }
    //реализация процессора
    public class TransactionProcessor : ITransactionProcessor
    {
        private readonly ICommissionStrategy _commissionStrategy;
        private readonly List<ITransactionObserver> _observers = new List<ITransactionObserver>();
        public TransactionProcessor(ICommissionStrategy commissionStrategy)
            => _commissionStrategy = commissionStrategy;
        public void Attach(ITransactionObserver observer) => _observers.Add(observer);
        public void Detach(ITransactionObserver observer) => _observers.Remove(observer);
        private void Notify(string eventType, Transaction transaction)
        {
            foreach (var observer in _observers)
                observer.Update(eventType, transaction);
        }
        public void ProcessTransaction(Transaction transaction)
        {
            try
            {
                //Валидация
                if (transaction.Amount <= 0)
                    throw new ArgumentException("Invalid amount");
                //Расчет комиссии
                transaction.Commission = _commissionStrategy.CalculateCommission(transaction.Amount);
                //Обработка 
                transaction.Status = TransactionStatus.Completed;
                Notify("PROCESSED", transaction);
            }
            catch (Exception ex)
            {
                Notify("ERROR", transaction);
                Logger.Instance.Log($"Error processing transaction {transaction.Id}: {ex.Message}");
                throw;
            }
        }
    }
    //Декоратор логирования
    public class LoggingDecorator : TransactionProcessorDecorator
    {
        public LoggingDecorator(ITransactionProcessor processor) : base(processor) { }
        public override
            void ProcessTransaction(Transaction transaction)
        {
            Logger.Instance.Log($"Processing transaction {transaction.Id} ({transaction.Type})");
            _processor.ProcessTransaction(transaction);
            Logger.Instance.Log($"Completed transaction {transaction.Id}");
        }
    }
    //Декоратор кэширования
    public class CachingDecorator : TransactionProcessorDecorator
    {
        private readonly Dictionary<Guid, Transaction> _cache = new Dictionary<Guid, Transaction>();
        public CachingDecorator(ITransactionProcessor processor) : base(processor) { }
        public override void ProcessTransaction(Transaction transaction)
        {
            if (_cache.ContainsKey(transaction.Id))
            {
                Logger.Instance.Log($"Using cached transaction {transaction.Id}");
                return;
            }
            _processor.ProcessTransaction(transaction);
            _cache[transaction.Id] = transaction;
        }
    }
    //транзакции
    public class TransactionCommand : ITransactionCommand
    {
        private readonly Transaction _transaction;
        private readonly ITransactionProcessor _processor;
        private TransactionStatus _previousStatus;
        public TransactionCommand(Transaction transaction, ITransactionProcessor processor)
        {
            _transaction = transaction;
            _processor = processor;
        }
        public void Execute()
        {
            _previousStatus = _transaction.Status;
            _processor.ProcessTransaction(_transaction);
        }
        public void Undo()
        {
            if (_transaction.Status == TransactionStatus.Completed)
            {
                _transaction.Status = _previousStatus;
                Logger.Instance.Log($"Undone transaction {_transaction.Id}");
            }
        }
    }
    //Наблюдатель
    public class EmailNotifier : ITransactionObserver
    {
        public void Update(string eventType, Transaction transaction)
        {
            if (eventType == "PROCESSED")
                Console.WriteLine($"Email: Transaction {transaction.Id} completed successfully!");
        }
    }
    //Фасад 
    public class FinancialSystemFacade
    {
        private readonly ITransactionProcessor _processor;
        private readonly Stack<ITransactionCommand> _commandHistory = new Stack<ITransactionCommand>();
        public FinancialSystemFacade(ICommissionStrategy commissionStrategy)
        {
            var processor = new TransactionProcessor(commissionStrategy);
            processor.Attach(new EmailNotifier());
            _processor = new CachingDecorator(
                new LoggingDecorator(processor));
        }
        public void ExecuteTransaction(Transaction transaction)
        {
            var command = new TransactionCommand(transaction, _processor);
            command.Execute();
            _commandHistory.Push(command);
        }
        public void UndoLastTransaction()
        {
            if (_commandHistory.Count > 0)
                _commandHistory.Pop().Undo();
        }
    }
    public class BankAccount
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
    }
    public static class BankData
    {
        public static List<BankAccount> Accounts = new List<BankAccount>();
        public static List<Transaction> TransactionHistory = new List<Transaction>();
    }
    class Program
    {
        static void Main()
        {
            var facade = new FinancialSystemFacade(new PercentageCommission(1.5m));
            BankData.Accounts.AddRange(new[]
            {
            new BankAccount { Number = "A70C097097001", Balance = 10_000 },
            new BankAccount { Number = "798CB089696902", Balance = 5_000 },
            new BankAccount { Number = "XYZ123456789", Balance = 15_000 }
        });
            while (true)
            {
                Console.WriteLine("\nБанковская система");
                Console.WriteLine("1. Создать новый счет");
                Console.WriteLine("2. Показать все счета");
                Console.WriteLine("3. Выполнить перевод");
                Console.WriteLine("4. Показать историю транзакций");
                Console.WriteLine("5. Показать баланс счета");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateNewAccount(); break;
                    case "2": ShowAllAccounts(); break;
                    case "3": ExecuteTransfer(facade); break;
                    case "4": ShowTransactionHistory(); break;
                    case "5": ShowAccountBalance(); break;
                    case "0": return;
                    default: Console.WriteLine("Ошибка: неверный выбор!"); break;
                }
            }
        }
        private static void CreateNewAccount()
        {
            Console.Write("Введите номер нового счета: ");
            var accountNumber = Console.ReadLine();

            Console.Write("Введите начальный баланс: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal balance))
            {
                BankData.Accounts.Add(new BankAccount { Number = accountNumber, Balance = balance });
                Console.WriteLine($"Счет {accountNumber} создан с балансом {balance} руб.");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректная сумма!");
            }
        }
        private static void ShowAllAccounts()
        {
            Console.WriteLine("\nСписок счетов:");
            foreach (var account in BankData.Accounts)
            {
                Console.WriteLine($"{account.Number}: {account.Balance} руб.");
            }
        }
        private static void ExecuteTransfer(FinancialSystemFacade facade)
        {
            Console.Write("Введите номер счета отправителя: ");
            var fromAccount = Console.ReadLine();

            Console.Write("Введите номер счета получателя: ");
            var toAccount = Console.ReadLine();

            Console.Write("Введите сумму перевода: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Ошибка: некорректная сумма!");
                return;
            }
            var sender = BankData.Accounts.FirstOrDefault(a => a.Number == fromAccount);
            if (sender == null)
            {
                Console.WriteLine("Ошибка: счет отправителя не найден!");
                return;
            }
            if (sender.Balance < amount)
            {
                Console.WriteLine("Ошибка: недостаточно средств!");
                return;
            }
            var transaction = new Transaction
            {
                Type = TransactionType.Payment,
                Amount = amount,
                FromAccount = fromAccount,
                ToAccount = toAccount
            };
            facade.ExecuteTransaction(transaction);

            sender.Balance -= amount;
            var receiver = BankData.Accounts.FirstOrDefault(a => a.Number == toAccount);
            if (receiver != null)
            {
                receiver.Balance += amount;
            }
            BankData.TransactionHistory.Add(transaction);

            Console.WriteLine($"Перевод {amount} руб. выполнен успешно!");
        }
        private static void ShowTransactionHistory()
        {
            Console.WriteLine("\nИстория транзакций:");
            foreach (var transaction in BankData.TransactionHistory)
            {
                Console.WriteLine($"[{transaction.Id}] {transaction.FromAccount} -> {transaction.ToAccount}: {transaction.Amount} руб. ({transaction.Status})");
            }
        }

        private static void ShowAccountBalance()
        {
            Console.Write("Введите номер счета:");
            var accountNumber = Console.ReadLine();

            var account = BankData.Accounts.FirstOrDefault(a => a.Number == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Ошибка: счет не найден!");
                return;
            }
            Console.WriteLine($"Баланс счета {account.Number}: {account.Balance} руб.");
        }
    }
}