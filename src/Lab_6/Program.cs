
namespace Lab6{
    class Program
    {
        static void Main(string[] args)
        {   
            // Task1 Перевірка парності числа 
            Console.WriteLine("Завдання 1: Перевірка парності"); 
            Task1(); 
            Console.WriteLine();
            // Task2 Перевірка оцінки студента
            Console.WriteLine("Завдання 2: Перевірка оцінки");
            Task2();
            Console.WriteLine();

            // Task3 Визначення дня тижня
            Console.WriteLine("Завдання 3: День тижня");
            Task3();
            Console.WriteLine();

            // Task4 Вибір автомобіля
            Console.WriteLine("Завдання 4: Вибір автомобіля");
            Task4();
            Console.WriteLine();

            // Task5 Тернарний оператор
            Console.WriteLine("Завдання 5: Температура");
            Task5();
            Console.WriteLine();

            // Task6 Обробка помилки
            Console.WriteLine("Завдання 6: Ділення чисел");
            Task6();
        }

        // Task1
        private static void Task1()
        {
            Console.Write("Введіть число: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number % 2 == 0)
                    Console.WriteLine("Число парне.");
                else
                    Console.WriteLine("Число непарне.");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректне число");
            }
        }

        // Task2
        private static void Task2()
        {
            Console.Write("Введіть вашу оцінку (0-100): ");
            if (int.TryParse(Console.ReadLine(), out int score))
            {
                if (score >= 90 && score <= 100)
                    Console.WriteLine("Ваша оцінка: A");
                else if (score >= 75)
                    Console.WriteLine("Ваша оцінка: B");
                else if (score >= 60)
                    Console.WriteLine("Ваша оцінка: C");
                else if (score >= 0)
                    Console.WriteLine("Ваша оцінка: F");
                else
                    Console.WriteLine("Помилка: оцінка має бути від 0 до 100");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректну оцінку");
            }
        }

        // Task3
        private static void Task3()
        {
            Console.Write("Введіть число (1-7): ");
            if (int.TryParse(Console.ReadLine(), out int day))
            {
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Понеділок");
                        break;
                    case 2:
                        Console.WriteLine("Вівторок");
                        break;
                    case 3:
                        Console.WriteLine("Середа");
                        break;
                    case 4:
                        Console.WriteLine("Четвер");
                        break;
                    case 5:
                        Console.WriteLine("П’ятниця");
                        break;
                    case 6:
                        Console.WriteLine("Субота");
                        break;
                    case 7:
                        Console.WriteLine("Неділя");
                        break;
                    default:
                        Console.WriteLine("Невідомий день");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректне число");
            }
        }

        // Task4
        private static void Task4()
        {
            Console.Write("Введіть марку авто (Toyota, BMW, Tesla): ");
            string carBrand = Console.ReadLine()?.ToLower();
            switch (carBrand)
            {
                case "toyota":
                    Console.WriteLine("Японія");
                    break;
                case "bmw":
                    Console.WriteLine("Німеччина");
                    break;
                case "tesla":
                    Console.WriteLine("США");
                    break;
                default:
                    Console.WriteLine("Невідома марка авто");
                    break;
            }
        }

        // Task5
        private static void Task5()
        {
            Console.Write("Введіть температуру: ");
            if (int.TryParse(Console.ReadLine(), out int temperature))
            {
                string result = temperature >= 0 ? "Погода тепла" : "Погода холодна";
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректну температуру");
            }
        }

        // Task6
        private static void Task6()
        {
            try
            {
                Console.Write("Введіть перше число: ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Помилка: введіть коректне число");
                    return;
                }

                Console.Write("Введіть друге число: ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("Помилка: введіть коректне число");
                    return;
                }

                int result = a / b;
                Console.WriteLine($"Результат: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Помилка: поділ на нуль!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Інша помилка: {ex.Message}");
            }
        }
    }

}