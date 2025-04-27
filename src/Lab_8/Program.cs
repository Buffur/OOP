namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Фільтрація чисел, що діляться на 3 або 5 
            Task1();
            Console.WriteLine();
            // Аналіз цін товарів
            Task2();
        }

        // Task1
        private static void Task1()
        {
            int[] numbers = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };
            var filtered = numbers.Where(n => n % 3 == 0 || n % 5 == 0).ToList();
            int sum = filtered.Sum();

            Console.WriteLine("Числа, що діляться на 3 або 5: " + string.Join(", ", filtered));
            Console.WriteLine($"Сума: {sum}");
        }

        // Task2
        private static void Task2()
        {
            string[] productNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
            double[] productPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };

            double averagePrice = productPrices.Average();
            Console.WriteLine($"Середня ціна: {averagePrice:F2} грн");

            Console.WriteLine("Товари, дорожчі за середню ціну:");
            var expensiveProducts = productNames
                .Zip(productPrices, (name, price) => new { Name = name, Price = price })
                .Where(p => p.Price > averagePrice);
            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name}: {product.Price:F2} грн");
            }

            int minIndex = Array.IndexOf(productPrices, productPrices.Min());
            int maxIndex = Array.IndexOf(productPrices, productPrices.Max());
            Console.WriteLine($"Найдешевший товар: {productNames[minIndex]} ({productPrices[minIndex]:F2} грн)");
            Console.WriteLine($"Найдорожчий товар: {productNames[maxIndex]} ({productPrices[maxIndex]:F2} грн)");
        }
    }

}