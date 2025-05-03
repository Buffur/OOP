using System;
using System.Collections.Generic;

namespace Lab25
{
    class Program
    {
        static void Main(string[] args)
        { // Task1. Strategy
           Console.Write("Оберіть стратегію (add/subtract/multiply): ");
           string strategyType = Console.ReadLine();
           ICalculationStrategy strategy = strategyType switch { "add" => new AddStrategy(), "subtract" => new SubtractStrategy(), "multiply" => new MultiplyStrategy(), _ => throw new ArgumentException("Невідома стратегія") };
           Calculator calculator = new Calculator(strategy); int result = calculator.Calculate(10, 5);
           Console.WriteLine($"Результат: {result}"); Console.WriteLine();

            // Task2. Command
            Editor editor = new Editor();
            ICommand open = new OpenFileCommand();
            ICommand save = new SaveFileCommand();
            ICommand close = new CloseFileCommand();
            editor.ExecuteCommand(open);
            editor.ExecuteCommand(save);
            editor.ExecuteCommand(close);
            Console.WriteLine();

            // Task3. Mediator
            ChatMediator chat = new ChatMediator();
            User user1 = new User("Аліна", chat);
            User user2 = new User("Богдан", chat);
            User user3 = new User("Віктор", chat);
            chat.Register(user1);
            chat.Register(user2);
            chat.Register(user3);
            user1.Send("Привіт усім!");
            Console.WriteLine();

            // Task4. Observer
            WeatherStation station = new WeatherStation();
            PhoneApp phone1 = new PhoneApp("UA001");
            PhoneApp phone2 = new PhoneApp("UA002");
            Billboard billboard = new Billboard("Центральна");
            station.Subscribe(phone1);
            station.Subscribe(phone2);
            station.Subscribe(billboard);
            station.Notify("Температура: +26°C, сонячно");
        }
    }

    // Task1
    public interface ICalculationStrategy
    {
        int Calculate(int a, int b);
    }

    public class AddStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            Console.WriteLine("Додавання");
            return a + b;
        }
    }

    public class SubtractStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            Console.WriteLine("Віднімання");
            return a - b;
        }
    }

    public class MultiplyStrategy : ICalculationStrategy
    {
        public int Calculate(int a, int b)
        {
            Console.WriteLine("Множення");
            return a * b;
        }
    }

    public class Calculator
    {
        private readonly ICalculationStrategy _strategy;

        public Calculator(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public int Calculate(int a, int b)
        {
            return _strategy.Calculate(a, b);
        }
    }

    // Task2
    public interface ICommand
    {
        void Execute();
    }

    public class OpenFileCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Відкрити файл");
        }
    }

    public class SaveFileCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Зберегти файл");
        }
    }

    public class CloseFileCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Закрити файл");
        }
    }

    public class Editor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }

    // Task3
    public interface IChatMediator
    {
        void Send(string message, User user);
        void Register(User user);
    }

    public class ChatMediator : IChatMediator
    {
        private readonly List<User> _users = new();

        public void Register(User user)
        {
            _users.Add(user);
        }

        public void Send(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message);
                }
            }
        }
    }

    public class User
    {
        public string Name { get; }
        private readonly IChatMediator _mediator;

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} надсилає: {message}");
            _mediator.Send(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name} отримав: {message}");
        }
    }

    // Task4
    public interface IObserver
    {
        void Update(string message);
    }

    public class PhoneApp : IObserver
    {
        private readonly string _id;

        public PhoneApp(string id)
        {
            _id = id;
        }

        public void Update(string message)
        {
            Console.WriteLine($"App {_id}: {message}");
        }
    }

    public class Billboard : IObserver
    {
        private readonly string _location;

        public Billboard(string location)
        {
            _location = location;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Billboard {_location}: {message}");
        }
    }

    public class WeatherStation
    {
        private readonly List<IObserver> _subscribers = new();

        public void Subscribe(IObserver observer)
        {
            _subscribers.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _subscribers)
            {
                observer.Update(message);
            }
        }
    }

}