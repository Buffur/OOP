using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services => {services.AddTransient<IGreetingService, GreetingService>();services.AddTransient<App>();}).Build();

            var app = host.Services.GetRequiredService<App>();
            app.Run();
        }
    }

    public interface IGreetingService
    {
        void Greet(string name);
    }

    public class GreetingService : IGreetingService
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Привіт, {name}!");
        }
    }

    public class App
    {
        private readonly IGreetingService _greeting;

        public App(IGreetingService greeting)
        {
            _greeting = greeting;
        }

        public void Run()
        {
            Console.Write("Введіть ім’я: ");
            string name = Console.ReadLine();
            _greeting.Greet(name);
        }
    }

}