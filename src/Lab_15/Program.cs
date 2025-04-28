using System.Diagnostics;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1. Використання Parallel.Invoke
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.Invoke(PrintNumbers,() => CalculateFactorial(10),() => Console.WriteLine(" Час виконання (вимірюється в реальному часі)"));
            stopwatch.Stop();
            Console.WriteLine($"Загальний час виконання: {stopwatch.ElapsedMilliseconds} мс");
            Console.WriteLine();


            // Task2. Демонстрація гонки потоків і її вирішення
            // Завдання 2: Демонстрація гонки потоків
            Console.WriteLine("Завдання 2: Демонстрація гонки потоків");

            // Без захисту (гонка потоків)
            int counterNoSync = 0;
            Parallel.For(0, 1000, i => counterNoSync++);
            Console.WriteLine($"Результат без захисту: {counterNoSync} (очікується 1000)");

            // З використанням lock
            int counterWithLock = 0;
            object locker = new object();
            Parallel.For(0, 1000, i =>
            {
                lock (locker)
                {
                    counterWithLock++;
                }
            });
            Console.WriteLine($"Результат з lock: {counterWithLock} (очікується 1000)");

            // З використанням Interlocked
            int counterWithInterlocked = 0;
            Parallel.For(0, 1000, i => Interlocked.Increment(ref counterWithInterlocked));
            Console.WriteLine($"Результат з Interlocked: {counterWithInterlocked} (очікується 1000)");
        }

        // Метод для виведення чисел від 1 до 500 (Завдання 1)
        static void PrintNumbers()
        {
            for (int i = 1; i <= 500; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        // Метод для обчислення факторіалу (Завдання 1)
        static long CalculateFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Число не може бути від’ємним");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факторіал {n} = {result}");
            return result;
        }
    }

}