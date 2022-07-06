
using CorsoCSharp.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CorsoCSharp
{
    internal class _48_Linq
    {
        // Targeting a named method
        static bool NameLongerThanFour(string name) => name.Length > 4;

        public void TargetingMethodLINQ()
        {
            string[] names = new[] { "angela", "michela", "anna", "lisa" };

            Console.WriteLine("LINQ DEFERRED EXECUTION");

            var q1 = names.Where(name => name.EndsWith("m"));                       // Find all names that ends with m
            var q2 = from name in names where name.EndsWith("m") select name;       // same query but written using LINQ query comprehension syntax



            var query = names.Where(new Func<string, bool>(NameLongerThanFour));    // Delegate method. If true include the name
            var query2 = names.Where(NameLongerThanFour);                           // Simplifying the code by removing the explicit delegate instantiation
            var query3 = names.Where(name => name.Length > 4);                      // Simplifying the code using lambda expression

            query3.OrderBy(name => name.Length);                                    // LINQ che ordina l'elenco in base al criterio indicato

            query3.OrderBy(name => name.Length)
                .ThenBy(name => name);                                              // LINQ che ordina l'elenco in base al criterio indicato e ad un sottocriterio

            foreach (var name in query)
            {
                Console.WriteLine(name);                                            // stamperà tutti i nomi che hanno piu di 4 lettere
            }

            var query4 = names.Where(name => name.Length > 4)
                .Skip(6)
                .Take(7);

            var query4_Comprehension = from name in names
                                       where name.Length > 4
                                       select name
                                       .Skip(6)
                                       .Take(7);

            // Filter by object type
            List < Exception > exceptions = new()
            {
                new ArgumentException(),
                new NullReferenceException(),
                new ArgumentNullException(),
                new ArithmeticException(),
                new ApplicationException(),
                new InvalidOperationException(),
                new InvalidDataException(),
                new IndexOutOfRangeException()
            };

            IEnumerable<ArithmeticException> arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException>();      // find all data of type object
        }

        // Filtering and sorting sequences - LINQ 
        static void FilterAndSort()
        {
            using (NorthwindContext db = new())
            {
                DbSet<Product> allProducts = db.Products;
                IQueryable<Product> filteredProducts = allProducts.Where(product => product.Cost < 10M);                    // Filtering with LINQ
                IOrderedQueryable<Product> sortAndFiltered = filteredProducts.OrderByDescending(product => product.Cost);   // ordering with LINQ
            }
        }

        // Join LINQ
        static void JoinCategoriesAndProduct()
        {
            using (NorthwindContext db = new())
            {
                var queryJoin = db.Categories.Join(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryId,
                    innerKeySelector: products => products.CategoryId,
                    resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId });        // anonymous type

                foreach (var c in queryJoin)
                {
                    Console.WriteLine("{0}: {1} is in {2}",
                        arg0: c.ProductId,
                        arg1: c.ProductName,
                        arg2: c.CategoryName);
                }
            }
        }

        // GroupingJoin LINQ
        static void GroupJoinCategoriesAndProduct()
        {
            using (NorthwindContext db = new())
            {
                var queryGroup = db.Categories!.AsEnumerable().GroupJoin(
                    inner: db.Products!,
                    outerKeySelector: category => category.CategoryId,
                    innerKeySelector: products => products.CategoryId,
                    resultSelector: (c, matchingProducts) => new {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName)
                    });        // anonymous type

                foreach (var c in queryGroup)
                {
                    Console.WriteLine("{0}: {1} is in {2}",
                        arg0: c.CategoryName,
                        arg1: c.Products.Count());
                }
            }
        }

        // Aggregate sequences LINQ
        static void AggregateProducts()
        {
            using (NorthwindContext db = new())
            {
                Console.WriteLine("{0,-25} {1,10}",
                    arg0: "Product count:",
                    arg1: db.Products!.Count());

                Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Higheest product price:",
                    arg1: db.Products!.Max());

                Console.WriteLine("{0,-25} {1,10:N0}",
                    arg0: "Sum of unit price:",
                    arg1: db.Products!.Sum(p => p.Cost));

                Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Avarage unit price:",
                    arg1: db.Products!.Average(p => p.Cost));

                Console.WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: db.Products,
                    arg1: db.Products!.Sum(p => p.Cost * p.UnitsInStock));

            }
        }
    }
}
