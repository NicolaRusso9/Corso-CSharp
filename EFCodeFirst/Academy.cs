using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    internal class Academy :  DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // For SQLite
            //string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");

            //Console.WriteLine($"Using {path} database file.");
            //optionBuilder.UseSqlite($"Filename={path}");

            // For sqlserver
            optionBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Student>()
                .Property(s => s.LastName)
                .HasMaxLength(30)
                .IsRequired(true);

            // populate table with sample data
            Student alice = new()
            {
                StudentId = 1,
                FirstName = "Alice",
                LastName = "Smith"
            };

            Student giorgia = new()
            {
                StudentId = 2,
                FirstName = "Giorgia",
                LastName = "Grey"
            };

            Course csharp = new()
            {
                CourseId = 1,
                Title = "C#10 and .NET 6"
            };

            Course webdev = new()
            {
                CourseId = 2,
                Title = "Web Development"
            };

            modelBuilder.Entity<Student>()
                .HasData(alice, giorgia);

            modelBuilder.Entity<Course>()
                .HasData(webdev, csharp);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(e => e.HasData(
                        new { CoursesCourseId = 1, StudentsStudentId = 1 },
                        new { CoursesCourseId = 2, StudentsStudentId = 1 },
                        new { CoursesCourseId = 1, StudentsStudentId = 2 }
                    ));
        }
    }
}
