namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню розрахунку іпотеки:");
                Console.WriteLine("1. Розрахувати щомісячний платіж");
                Console.WriteLine("2. Вийти");
                Console.Write("Виберіть опцію (1-2): ");

                string input = Console.ReadLine();
                if (input == "2") break;

                if (input == "1")
                {
                    CalculateMortgagePayment();
                }
                else
                {
                    Console.WriteLine("Помилка: виберіть 1 або 2");
                }
            }
        }

        private static void CalculateMortgagePayment()
        {
            try
            {
                Console.Write("Введіть суму кредиту (P): ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal principal) || principal <= 0)
                {
                    Console.WriteLine("Помилка: сума кредиту має бути позитивним числом");
                    return;
                }

                Console.Write("Введіть річну відсоткову ставку (%): ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal annualRate) || annualRate <= 0)
                {
                    Console.WriteLine("Помилка: відсоткова ставка має бути позитивним числом");
                    return;
                }

                Console.Write("Введіть термін кредиту (роки): ");
                if (!int.TryParse(Console.ReadLine(), out int years) || years <= 0)
                {
                    Console.WriteLine("Помилка: термін має бути позитивним цілим числом");
                    return;
                }

                decimal monthlyRate = annualRate / 12 / 100;
                int months = years * 12;
                decimal ratePower = (decimal)Math.Pow((double)(1 + monthlyRate), months);
                decimal monthlyPayment = principal * monthlyRate * ratePower / (ratePower - 1);

                monthlyPayment = Math.Round(monthlyPayment, 2);

                Console.WriteLine($"Щомісячний платіж: {monthlyPayment:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

}