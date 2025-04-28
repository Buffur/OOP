using System;
using System.Threading.Tasks;

namespace Lab16
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BankAccount account = new BankAccount();

            await account.DepositAsync(200);
            await account.WithdrawAsync(100);
            await account.DepositAsync(300);
            await account.WithdrawAsync(50);

            Console.WriteLine($"Фінальний баланс: {account.Balance}");
        }
    }

    class BankAccount
    {
        private int balance = 0;
        private readonly object locker = new object();

        public int Balance => balance;

        public async Task DepositAsync(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума поповнення має бути позитивною");

            await Task.Delay(100);

            lock (locker)
            {
                balance += amount;
                Console.WriteLine($"Поповнення +{amount}");
            }
        }

        public async Task WithdrawAsync(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума зняття має бути позитивною");

            await Task.Delay(100);

            lock (locker)
            {
                if (balance < amount)
                    throw new InvalidOperationException("Недостатньо коштів");

                balance -= amount;
                Console.WriteLine($"Зняття -{amount}");
            }
        }
    }

}