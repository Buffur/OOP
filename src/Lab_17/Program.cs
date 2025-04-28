using System;

namespace Lab17
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1. Тестування класу Student
            Student student = new Student();
            student.Name = "Андрій";
            student.Age = 25;
            Console.WriteLine($"Ім'я: {student.Name}, Вік: {student.Age}");

            student.Age = -5;
            student.Age = 150;
            Console.WriteLine();

            // Task2. Тестування класу Car
            Car car = new Car();
            car.Accelerate(50);
            Console.WriteLine($"Поточна швидкість: {car.Speed}");

            car.Accelerate(30);
            Console.WriteLine($"Поточна швидкість: {car.Speed}");

            car.Brake(20);
            Console.WriteLine($"Поточна швидкість: {car.Speed}");

            car.Brake(100);
            Console.WriteLine($"Поточна швидкість: {car.Speed}");
        }
    }
    // Task1
    public class Student
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Некоректний вік. Вік має бути від 0 до 120.");
                }
            }
        }
    }
    // Task2
    public class Car
    {
        private int speed;

        public int Speed
        {
            get { return speed; }
        }

        public void Accelerate(int amount)
        {
            if (amount > 0)
            {
                speed += amount;
                Console.WriteLine($"Прискорення на {amount}.");
            }
            else
            {
                Console.WriteLine("Сума прискорення має бути позитивною.");
            }
        }

        public void Brake(int amount)
        {
            if (amount > 0)
            {
                if (speed >= amount)
                {
                    speed -= amount;
                    Console.WriteLine($"Гальмування на {amount}.");
                }
                else
                {
                    speed = 0;
                    Console.WriteLine($"Гальмування на {amount} неможливе. Швидкість встановлено на 0.");
                }
            }
            else
            {
                Console.WriteLine("Сума гальмування має бути позитивною.");
            }
        }
    }

}