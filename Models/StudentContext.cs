// File: Models/StudentContext.cs
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.student_id); // Ensure this matches the property name in the Student class
        }
    }
}
