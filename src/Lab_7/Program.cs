namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        { // Виведення парних чисел 
            Task1();
            Console.WriteLine();
            // Підрахунок суми
            Task2();
            Console.WriteLine();
            // Введення пароля
            Task3();
        }
        // Task1 Виведення парних чисел (for)
        private static void Task1()
        {
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        // Task2 Підрахунок суми (while)
        private static void Task2()
        {
            int sum = 0;
            int number;
            while (true)
            {
                Console.Write("Введіть число (0 для завершення): ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number == 0)
                        break;
                    sum += number;
                }
                else
                {
                    Console.WriteLine("Помилка: введіть коректне число");
                }
            }
            Console.WriteLine($"Сума: {sum}");
        }

        // Task1 Введення пароля (do-while)
        private static void Task3()
        {
            string correctPassword = "1234";
            string input;
            do
            {
                Console.Write("Введіть пароль: ");
                input = Console.ReadLine();
                if (input != correctPassword)
                {
                    Console.WriteLine("Неправильний пароль!");
                }
            } while (input != correctPassword);
            Console.WriteLine("Доступ дозволено!");
        }
    }

}