using System;
using System.Collections.Generic;

namespace Lab18
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1. Інтерфейс IAnimal
            List<IAnimal> animals = new List<IAnimal> { new Dog(), new Cat() };

            foreach (var animal in animals)
            {
                animal.Speak();
                animal.Eat();
            }
            Console.WriteLine();

            // Task2. Інтерфейс IPaymentMethod
            Order order1 = new Order(new CreditCard());
            order1.ProcessPayment(500);

            Order order2 = new Order(new PayPal());
            order2.ProcessPayment(250);

            Order order3 = new Order(new ApplePay());
            order3.ProcessPayment(300);
        }
    }

    // Task1
    public interface IAnimal
    {
        void Speak();
        void Eat();
    }

    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Собака: Гав-гав!");
        }

        public void Eat()
        {
            Console.WriteLine("Собака їсть кістку.");
        }
    }

    public class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Кіт: Мяу-мяу!");
        }

        public void Eat()
        {
            Console.WriteLine("Кіт їсть рибу.");
        }
    }

    // Task2
    public interface IPaymentMethod
    {
        void Pay(decimal amount);
    }

    public class CreditCard : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
        }
    }

    public class PayPal : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата через PayPal: {amount} грн");
        }
    }

    public class ApplePay : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата через ApplePay: {amount} грн");
        }
    }

    public class Order
    {
        public IPaymentMethod PaymentMethod { get; set; }

        public Order(IPaymentMethod paymentMethod)
        {
            PaymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
        }

        public void ProcessPayment(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума платежу має бути позитивною");

            Console.WriteLine("Обробка платежу...");
            PaymentMethod.Pay(amount);
            Console.WriteLine("Платіж завершено.\n");
        }
    }

}