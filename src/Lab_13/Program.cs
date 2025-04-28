using System;
using System.Collections.Generic;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        { // Task1. Фільтрація чисел
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Predicate<int> isEven = n => n % 2 == 0;
            int[] evenNumbers = Filter(numbers, isEven);

            Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));
            Console.WriteLine();

            // Task2. Сповіщення про зміну статусу замовлення
            Order order = new Order();
            order.OrderStatusChanged += OrderStatusChangedHandler;
            order.Status = "Замовлення отримано";
            order.Status = "Відправлено";
            order.Status = "Доставлено";

            // Task1
            static int[] Filter(int[] numbers, Predicate<int> predicate)
            {
                if (numbers == null)
                    throw new ArgumentNullException(nameof(numbers));

                List<int> result = new List<int>();
                foreach (var number in numbers)
                {
                    if (predicate(number))
                        result.Add(number);
                }
                return result.ToArray();
            }

            // Task2
            static void OrderStatusChangedHandler(object sender, string status)
            {
                Console.WriteLine($"Статус замовлення змінено на: {status}");
            }
        }

        // Task2
        class Order
        {
            public event EventHandler<string> OrderStatusChanged;
            private string status;

            public string Status
            {
                get => status;
                set
                {
                    if (status != value)
                    {
                        if (string.IsNullOrWhiteSpace(value))
                            throw new ArgumentException("Статус не може бути порожнім");

                        status = value;
                        OnOrderStatusChanged(status);
                    }
                }
            }

            protected virtual void OnOrderStatusChanged(string status)
            {
                OrderStatusChanged?.Invoke(this, status);
            }
        }
    }
}