using Lab32.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab32
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // Наповнення даними
            var group = new Group { Name = "CS-101" };
            db.Groups.Add(group);

            db.People.AddRange(
                new Student { Name = "Анна", Age = 19, StudentNumber = "S123", Group = group },
                new Student { Name = "Іван", Age = 17, StudentNumber = "S456", Group = group },
                new Student { Name = "Марія", Age = 20, StudentNumber = "S789", Group = group },
                new Teacher { Name = "Др. Сміт", Age = 45, Department = "Математика" },
                new Teacher { Name = "Проф. Джонсон", Age = 50, Department = "Математика" },
                new Teacher { Name = "Др. Браун", Age = 38, Department = "Фізика" }
            );

            db.SaveChanges();

            // Запит 1: Студенти старші 18 років
            var adultStudents = db.Students
                .Where(s => s.Age > 18)
                .ToList();
            Console.WriteLine("Студенти старші 18 років:");
            foreach (var s in adultStudents)
                Console.WriteLine($"{s.Name} ({s.Age}, Номер студента: {s.StudentNumber})");

            // Запит 2: Викладачі кафедри "Математика"
            var mathTeachers = db.Teachers
                .Where(t => t.Department == "Математика")
                .ToList();
            Console.WriteLine("\nВикладачі кафедри Математика:");
            foreach (var t in mathTeachers)
                Console.WriteLine($"{t.Name} (Вік: {t.Age})");

            // Запит 3: Фільтрація за ім’ям (наприклад, містить "а")
            var peopleWithA = db.People
                .Where(p => p.Name.Contains("а"))
                .ToList();
            Console.WriteLine("\nЛюди з 'а' в імені:");
            foreach (var p in peopleWithA)
                Console.WriteLine($"{p.Name} ({(p is Student ? "Студент" : "Викладач")})");

            // Запит 4: Студенти з групами через Include
            var studentsWithGroups = db.Students
                .Include(s => s.Group)
                .ToList();
            Console.WriteLine("\nСтуденти з їхніми групами:");
            foreach (var s in studentsWithGroups)
                Console.WriteLine($"{s.Name} -> {s.Group?.Name ?? "Немає групи"}");
        }
    }
}