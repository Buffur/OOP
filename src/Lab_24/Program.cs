namespace Lab24
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1. Adapter
            OldPrinter oldPrinter = new OldPrinter();
            INewPrinter printerAdapter = new PrinterAdapter(oldPrinter);
            printerAdapter.Print("Тестовий документ");
            Console.WriteLine();

            // Task2. Facade
            CarFacade car = new CarFacade();
            car.StartCar();
            Console.WriteLine();

            // Task3. Decorator
            IWriter writer = new TimestampWriter(new ConsoleWriter());
            writer.Write("Привіт, світ!");
        }
    }

    // Task1
    public interface INewPrinter
    {
        void Print(string message);
    }

    public class OldPrinter
    {
        public void OldPrint()
        {
            Console.WriteLine("Старий принтер друкує");
        }
    }

    public class PrinterAdapter : INewPrinter
    {
        private readonly OldPrinter _oldPrinter;

        public PrinterAdapter(OldPrinter oldPrinter)
        {
            _oldPrinter = oldPrinter;
        }

        public void Print(string message)
        {
            Console.WriteLine($"Адаптер: Передаємо повідомлення '{message}'");
            _oldPrinter.OldPrint();
        }
    }

    // Task2
    public class Engine
    {
        public void Start() => Console.WriteLine("Двигун запущено");
    }

    public class Battery
    {
        public void Start() => Console.WriteLine("Акумулятор активовано");
    }

    public class IgnitionSystem
    {
        public void Start() => Console.WriteLine("Система запалювання увімкнена");
    }

    public class CarFacade
    {
        private readonly Engine _engine = new();
        private readonly Battery _battery = new();
        private readonly IgnitionSystem _ignition = new();

        public void StartCar()
        {
            _battery.Start();
            _ignition.Start();
            _engine.Start();
            Console.WriteLine("Автомобіль готовий до руху");
        }
    }

    // Task3
    public interface IWriter
    {
        void Write(string text);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class TimestampWriter : IWriter
    {
        private readonly IWriter _inner;

        public TimestampWriter(IWriter inner)
        {
            _inner = inner;
        }

        public void Write(string text)
        {
            string stamped = $"[{DateTime.Now:HH:mm:ss}] {text}";
            _inner.Write(stamped);
        }
    }

}