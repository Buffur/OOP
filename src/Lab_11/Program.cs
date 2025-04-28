using System.Text.RegularExpressions;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню");
                Console.WriteLine("1. Система обробки заявок (Queue)");
                Console.WriteLine("2. Аналіз тексту (Dictionary)");
                Console.WriteLine("3. Вийти");
                Console.Write("Виберіть опцію (1-3): ");

                string input = Console.ReadLine();
                if (input == "3") break;

                switch (input)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    default:
                        Console.WriteLine("Помилка: виберіть 1, 2 або 3");
                        break;
                }
            }
        }

        // Task1. Система обробки заявок
        private static void Task1()
        {
            Queue<string> requests = new Queue<string>();
            while (true)
            {
                Console.WriteLine("\nМеню обробки заявок:");
                Console.WriteLine("1. Додати заявку");
                Console.WriteLine("2. Обробити заявку");
                Console.WriteLine("3. Подивитися першу заявку");
                Console.WriteLine("4. Показати всі заявки");
                Console.WriteLine("5. Повернутися до головного меню");
                Console.Write("Виберіть опцію (1-5): ");

                string choice = Console.ReadLine();
                if (choice == "5") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть текст заявки: ");
                        string request = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(request))
                        {
                            requests.Enqueue(request);
                            Console.WriteLine("Заявку додано!");
                        }
                        else
                        {
                            Console.WriteLine("Помилка: заявка не може бути порожньою");
                        }
                        break;

                    case "2":
                        if (requests.Count > 0)
                        {
                            string processed = requests.Dequeue();
                            Console.WriteLine($"Заявка \"{processed}\" оброблена!");
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    case "3":
                        if (requests.Count > 0)
                        {
                            Console.WriteLine($"Перша заявка в черзі: \"{requests.Peek()}\"");
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    case "4":
                        if (requests.Count > 0)
                        {
                            Console.WriteLine("Усі заявки в черзі:");
                            foreach (var req in requests)
                            {
                                Console.WriteLine($"- {req}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    default:
                        Console.WriteLine("Помилка: виберіть 1-5");
                        break;
                }
            }
        }

        // Task 2. Аналіз тексту
        private static void Task2()
        {
            Console.WriteLine("\nВведіть текст для аналізу:");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Помилка: текст не може бути порожнім");
                return;
            }

            string[] words = Regex.Split(text.ToLower(), @"\W+")
                .Where(w => !string.IsNullOrEmpty(w))
                .ToArray();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                else
                    wordCounts[word] = 1;
            }

            var sortedWords = wordCounts.OrderByDescending(w => w.Value).ThenBy(w => w.Key);

            // Виводимо статистику
            Console.WriteLine("\nСтатистика повторень слів:");
            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"Слово \"{pair.Key}\": {pair.Value} раз(ів)");
            }
        }
    }

}