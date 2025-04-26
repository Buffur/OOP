using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {  
        Task1(); Task2(); Task3(); Task4(); Task5(); 
        }
    // Task 1
    private static void Task1()
        {
            int age = 25;
            double weight = 72.5;
            char grade = 'A';
            bool isStudent = true;
            string name = "Олександр";

            Console.WriteLine($"Вік: {age}");
            Console.WriteLine($"Вага: {weight}");
            Console.WriteLine($"Оцінка: {grade}");
            Console.WriteLine($"Студент: {isStudent}");
            Console.WriteLine($"Ім'я: {name}\n");
        }

        // Task 2
        private static void Task2()
        {
            Console.Write("Введіть число (double): ");
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                int intNumber = (int)number; // Явне перетворення в int
                string stringNumber = intNumber.ToString(); // Перетворення в string
                Console.WriteLine($"Введене число (double): {number}");
                Console.WriteLine($"Перетворене в int: {intNumber}");
                Console.WriteLine($"Перетворене в string: {stringNumber}\n");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректне число\n");
            }
        }

        // Task 3
        private static void Task3()
        {
            Console.Write("Введіть ваше ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Введіть ваш вік: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine($"Привіт, {name}! Твій вік: {age} років.\n");
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректний вік\n");
            }
        }

        // Task 4
        private static void Task4()
        {
            Console.Write("Введіть відстань (км): ");
            if (double.TryParse(Console.ReadLine(), out double distance))
            {
                Console.Write("Введіть час (год): ");
                if (double.TryParse(Console.ReadLine(), out double time) && time > 0)
                {
                    double speed = distance / time; // Обчислення швидкості
                    Console.WriteLine($"Середня швидкість: {speed} км/год\n");
                }
                else
                {
                    Console.WriteLine("Помилка: час має бути більше 0\n");
                }
            }
            else
            {
                Console.WriteLine("Помилка: введіть коректну відстань\n");
            }
        }

        // Task 5
        private static void Task5()
        {
            Console.Write("Введіть речення: ");
            string sentence = Console.ReadLine();
            if (!string.IsNullOrEmpty(sentence))
            {
                Console.WriteLine($"Довжина: {sentence.Length} символів");
                Console.WriteLine($"Верхній регістр: {sentence.ToUpper()}");
                Console.WriteLine($"Замінені пробіли: {sentence.Replace(" ", "-")}");
                string firstFive = sentence.Length >= 5 ? sentence.Substring(0, 5) : sentence;
                Console.WriteLine($"Перші 5 символів: {firstFive}\n");
            }
            else
            {
                Console.WriteLine("Помилка: введіть непорожнє речення\n");
            }
        }
    }

}