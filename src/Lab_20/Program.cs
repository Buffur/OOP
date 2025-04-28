using System;
using System.Collections.Generic;

namespace Lab20
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1. Абстрактні тварини
            List<Animal> animals = new List<Animal> { new Cat(), new Dog(), new Cow() };

            foreach (var animal in animals)
            {
                animal.MakeSound();
                animal.Sleep();
                Console.WriteLine();
            }

            // Task2. Платіжна система
            List<PaymentMethod> payments = new List<PaymentMethod>
        {
            new CreditCard(),
            new PayPal(),
            new ApplePay()
        };

            foreach (var payment in payments)
            {
                payment.Pay(100);
                payment.Confirm();
                Console.WriteLine();
            }
        }
    }

    // Task1
    public abstract class Animal
    {
        public abstract void MakeSound();

        public void Sleep()
        {
            Console.WriteLine("Тварина спить...");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Мяу!");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Гав!");
        }
    }

    public class Cow : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Мууу!");
        }
    }

    // Task2
    public abstract class PaymentMethod
    {
        public abstract void Pay(decimal amount);

        public void Confirm()
        {
            Console.WriteLine("Платіж підтверджено");
        }
    }

    public class CreditCard : PaymentMethod
    {
        public override void Pay(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума платежу має бути позитивною");
            Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
        }
    }

    public class PayPal : PaymentMethod
    {
        public override void Pay(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума платежу має бути позитивною");
            Console.WriteLine($"Оплата через PayPal: {amount} грн");
        }
    }

    public class ApplePay : PaymentMethod
    {
        public override void Pay(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума платежу має бути позитивною");
            Console.WriteLine($"Оплата через ApplePay: {amount} грн");
        }
    }

}