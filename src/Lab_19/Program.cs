using System;
using System.Collections.Generic;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1 Успадкування у транспортній системі
            Transport[] vehicles = new Transport[] { new Car { Name = "Автомобіль" }, new Bicycle { Name = "Велосипед" }, new Train { Name = "Потяг" } };

            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }
            Console.WriteLine();

            // Task2 Поліморфізм у роботі працівників
            List<Employee> employees = new List<Employee>
        {
            new Programmer(),
            new Designer(),
            new Manager()
        };

            foreach (var employee in employees)
            {
                employee.Work();
            }
        }
    }

    // Task1
    public class Transport
    {
        public string Name { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} рухається...");
        }
    }

    public class Car : Transport
    {
        public override void Move()
        {
            Console.WriteLine($"{Name} їде по дорозі.");
        }
    }

    public class Bicycle : Transport
    {
        public override void Move()
        {
            Console.WriteLine($"{Name} крутить педалі.");
        }
    }

    public class Train : Transport
    {
        public override void Move()
        {
            Console.WriteLine($"{Name} мчить по рейках.");
        }
    }

    // Task2
    public class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Працівник виконує роботу.");
        }
    }

    public class Programmer : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Програміст пише код.");
        }
    }

    public class Designer : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Дизайнер створює макети.");
        }
    }

    public class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Менеджер керує командою.");
        }
    }

}