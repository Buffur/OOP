using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_31
{
    // --- Моделі ---
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }

    public class Borrowing
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime BorrowDate { get; set; }
    }

    // --- Контекст ---
    public class LibraryContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library_db;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrowing>()
                .HasKey(b => new { b.StudentId, b.BookId });

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Student)
                .WithMany(s => s.Borrowings)
                .HasForeignKey(b => b.StudentId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.Borrowings)
                .HasForeignKey(b => b.BookId);
        }
    }

    // --- Програма ---
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Підключення до PostgreSQL...");

                // Автоматично створює базу даних, якщо ще не існує
                context.Database.EnsureCreated();

                if (!context.Students.Any())
                {
                    var student = new Student { FullName = "Олена Іваненко" };
                    var book = new Book { Title = "Бази даних", ISBN = "978-1234567890" };

                    context.Students.Add(student);
                    context.Books.Add(book);
                    context.SaveChanges();

                    context.Borrowings.Add(new Borrowing
                    {
                        StudentId = student.StudentId,
                        BookId = book.BookId,
                        BorrowDate = DateTime.UtcNow // 🟢 Використовуємо UTC для PostgreSQL
                    });

                    context.SaveChanges();

                    Console.WriteLine("Дані додано.");
                }
                else
                {
                    Console.WriteLine("Дані вже існують.");
                }
            }
        }

    }
}
