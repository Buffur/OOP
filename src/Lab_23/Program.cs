using System;

namespace Lab23
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1. Singleton
            Console.WriteLine("Завдання 1: Singleton");
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;
            logger1.Log("Перше повідомлення");
            logger2.Log("Друге повідомлення");
            Console.WriteLine($"Один екземпляр: {ReferenceEquals(logger1, logger2)}"); Console.WriteLine();

            // Task2. Factory Method
            Console.WriteLine("Завдання 2: Factory Method");
            Console.Write("Тип повідомлення (email/sms/push): ");
            string type = Console.ReadLine();
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Привіт, користувачу!");
            Console.WriteLine();

            // Task3. Builder
            Console.WriteLine("Завдання 3: Builder");
            ComputerBuilder builder = new ComputerBuilder();
            Computer gamingPC = builder
                .SetCPU("Intel i9")
                .SetGPU("NVIDIA RTX 3080")
                .SetRAM("32GB")
                .SetSSD("1TB")
                .Build();
            gamingPC.Show();

            Computer officePC = builder
                .SetCPU("Intel i5")
                .SetGPU("Integrated")
                .SetRAM("8GB")
                .SetSSD("256GB")
                .Build();
            officePC.Show();
        }
    }

    // Task1
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new Logger();
                    return _instance;
                }
            }
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}");
        }
    }

    // Task2
    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}");
    }

    public class SMSNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"SMS: {message}");
    }

    public class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Push: {message}");
    }

    public class NotificationFactory
    {
        public static INotification Create(string type)
        {
            return type switch
            {
                "email" => new EmailNotification(),
                "sms" => new SMSNotification(),
                "push" => new PushNotification(),
                _ => throw new ArgumentException("Невідомий тип")
            };
        }
    }

    // Task3
    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string SSD { get; set; }

        public void Show()
        {
            Console.WriteLine($"Комп'ютер: CPU={CPU}, GPU={GPU}, RAM={RAM}, SSD={SSD}");
        }
    }

    public class ComputerBuilder
    {
        private readonly Computer _computer = new();

        public ComputerBuilder SetCPU(string cpu)
        {
            _computer.CPU = cpu;
            return this;
        }

        public ComputerBuilder SetGPU(string gpu)
        {
            _computer.GPU = gpu;
            return this;
        }

        public ComputerBuilder SetRAM(string ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public ComputerBuilder SetSSD(string ssd)
        {
            _computer.SSD = ssd;
            return this;
        }

        public Computer Build() => _computer;
    }

}