using Microsoft.EntityFrameworkCore;

namespace Lab30
{
    public abstract class User
    {
        public int UserId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public List<Borrowing> Borrowings { get; set; } = new();
    }

    public class Reader : User
    {
        public DateTime MembershipDate { get; set; }
    }

    public class LibraryWorker : User
    {
        public required string Position { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public int YearPublished { get; set; }
    }

    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public required User User { get; set; }
        public required Book Book { get; set; }
    }

    public class LibraryContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<LibraryWorker> LibraryWorkers => Set<LibraryWorker>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Borrowing> Borrowings => Set<Borrowing>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LibraryDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>().HasBaseType<User>();
            modelBuilder.Entity<LibraryWorker>().HasBaseType<User>();

            modelBuilder.Entity<Borrowing>()
                .HasKey(b => b.BorrowingId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.User)
                .WithMany(u => u.Borrowings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    class Program
    {
        static void Main()
        {
            using var context = new LibraryContext();

            // Adding books
            var book1 = new Book { Title = "C# для початківців", YearPublished = 2020 };
            var book2 = new Book { Title = "Основи баз даних", YearPublished = 2021 };
            context.Books.AddRange(book1, book2);
            context.SaveChanges();

            // Adding users
            var reader = new Reader
            {
                FullName = "Олена Іваненко",
                Email = "olena@example.com",
                MembershipDate = DateTime.Now
            };

            var worker = new LibraryWorker
            {
                FullName = "Максим Бойко",
                Email = "maxym@example.com",
                Position = "Менеджер"
            };

            context.Readers.Add(reader);
            context.LibraryWorkers.Add(worker);
            context.SaveChanges();

            // Adding loans
            var borrowing1 = new Borrowing
            {
                UserId = reader.UserId,
                BookId = book1.BookId,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                User = reader,
                Book = book1
            };

            var borrowing2 = new Borrowing
            {
                UserId = worker.UserId,
                BookId = book2.BookId,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                User = worker,
                Book = book2
            };

            context.Borrowings.AddRange(borrowing1, borrowing2);
            context.SaveChanges();

            // Loan withdrawal
            var borrowings = context.Borrowings
                .Include(b => b.User)
                .Include(b => b.Book)
                .ToList();

            foreach (var b in borrowings)
            {
                Console.WriteLine($"{b.User.FullName} позичив(ла) \"{b.Book.Title}\" з {b.BorrowDate.ToShortDateString()} до {b.ReturnDate.ToShortDateString()}");
            }
        }
    }
}
