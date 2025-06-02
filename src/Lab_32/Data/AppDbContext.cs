using Microsoft.EntityFrameworkCore;
using Lab32.Models;

namespace Lab32
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Group> Groups => Set<Group>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=people.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher");

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);
        }
    }
}