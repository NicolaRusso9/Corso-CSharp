using Microsoft.EntityFrameworkCore;

namespace CorsoCSharp.EFCore
{
    internal class NorthwindContext  : DbContext
    {

        // these properties map to tables in the database
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseLazyLoadingProxies(); // Abilita il lazy loading. Lazy loading carica automaticamente i dati prima che siano richiesti

            if(ProjectConstants.DataBaseProvider == "SQLite")
            {
                string path = Path.Combine(Environment.CurrentDirectory, "NorthwindDB");
                Console.WriteLine($"Using {path} database file.");

                optionBuilder.UseSqlite(path);
            }
            else
            {
                string connection = "Data Source=.;" +
                    "Initial Catalog=Northwind;" +
                    "Integrated Security=true;" +
                    "MultipleActiveResultSets=true;";

                optionBuilder.UseSqlServer(connection);
            }
        }


        // Fluent API as an alternative to decorating entity classes with attributes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // little example of usage
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()   // NOT NULL
                .HasMaxLength(15);  // MAX LENGHT OF STRING    


            // global filter to remove discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
}
