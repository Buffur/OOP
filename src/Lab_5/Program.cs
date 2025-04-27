namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        { // Task1
            Console.WriteLine("Перевірка парності");
            Console.Write("Введіть ціле число: ");
            if (int.TryParse(Console.ReadLine(), out int number)) { 
                Console.WriteLine($"Число {number} парне: {IsEven(number)}"); 
            } 
            else { 
                Console.WriteLine("Помилка: введіть коректне ціле число"); 
            }
            // Task2
            Console.WriteLine("Перевантаження Sum");
            Console.WriteLine($"Сума (5, 10): {Sum(5, 10)}");
            Console.WriteLine($"Сума (2, 3, 4): {Sum(2, 3, 4)}");
            Console.WriteLine($"Сума (2.5, 3.1): {Sum(2.5, 3.1)}");
            Console.WriteLine();

            // Task3
            Console.WriteLine("Swap з ref");
            int a = 5, b = 10;
            Console.WriteLine($"До Swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"Після Swap: a = {a}, b = {b}");
        }

        // Task1
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        // Task2
        private static int Sum(int a, int b)
        {
            return a + b;
        }
        private static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
        private static double Sum(double a, double b)
        {
            return a + b;
        }
        // Task3
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

}