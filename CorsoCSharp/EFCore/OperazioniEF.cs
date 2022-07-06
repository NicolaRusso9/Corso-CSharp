using CorsoCSharp.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CorsoCSharp.EFCore
{
    internal class OperazioniEF
    {

        static void QueryingCategories()
        {
            using (NorthwindContext db = new())
            {
                Console.WriteLine("Categories and how many products they have:");
                db.ChangeTracker.LazyLoadingEnabled = false;        // disable lazy loading in context file that automatically load all data before its required

                IQueryable<Category>? categories;

                Console.Write("Enable Eager Loading? (Y/N):");
                bool eagerLoading = (Console.ReadKey().Key == ConsoleKey.Y);
                bool explicitLoading = false;

                Console.WriteLine();

                if (eagerLoading)
                {
                    // EAGER LOADING
                    categories = db.Categories?.Include(c => c.Products);     // Include keyword enable Eager loading, this means that it load all included object automatically
                }
                else
                {
                    categories = db.Categories;
                    Console.WriteLine("Enable Explicit Loading? (Y/N):");
                    explicitLoading = (Console.ReadKey().Key == ConsoleKey.Y);
                    Console.WriteLine();
                }

                if (categories is null)
                {
                    Console.WriteLine("No categories found");
                    return;
                }

                foreach (Category category in categories)
                {
                    if (explicitLoading)
                    {
                        // EXPLICIT LOADING
                        Console.Write($"Explicitly load products for {category.CategoryName}? (Y/N):");
                        ConsoleKeyInfo key = Console.ReadKey();
                        Console.WriteLine();

                        if (key.Key == ConsoleKey.Y)
                        {
                            CollectionEntry<Category, Product> products = db.Entry(category).Collection(category2 => category2.Products);
                            if (!products.IsLoaded) products.Load();
                        }
                    }

                    Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products");
                }
            }
            Console.WriteLine();
        }

        static void FilteredIncludes()
        {
            using (NorthwindContext db = new())
            {
                Console.WriteLine("Enter a minimum for units in stock:");
                string unitStock = Console.ReadLine() ?? "10";
                int stock = int.Parse(unitStock);

                // a query to get all categorie and their related products
                IQueryable<Category>? categories = db.Categories?
                    .Include(c => c.Products
                        .Where(p => p.Stock >= stock)               // filter
                    ).OrderByDescending(c => c.CategoryName);       // sorting

                if (categories is null)
                {
                    Console.WriteLine("No categories found");
                    return;
                }

                foreach (Category category in categories)
                {
                    Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum of {stock} units in stock.");

                    foreach (Product product in category.Products)
                    {
                        Console.WriteLine($"{product.ProductName} has {product.Stock} units in stock");
                    }
                }
            }
            Console.WriteLine();
        }

        static void ShowSQLQueryAndLogging()
        {
            using (NorthwindContext db = new())
            {
                ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());             // Show information 

                Console.WriteLine("Enter a minimum for units in stock:");
                string unitStock = Console.ReadLine() ?? "10";
                int stock = int.Parse(unitStock);

                // a query to get all categorie and their related products
                IQueryable<Category>? categories = db.Categories?
                    .TagWith("categories queries")                  // annotate a linq query to correlate log messages (like sql comment)
                    .Include(c => c.Products
                        .Where(p => p.Stock >= stock)               // filter
                    ).OrderByDescending(c => c.CategoryName);       // sorting

                Console.WriteLine($"ToQueryString: {categories.ToQueryString()}");      // Show SQL query
                Console.WriteLine();
            }
        }

        static void QueryingWithLike()
        {
            using (NorthwindContext db = new())
            {
                ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());             // Show information 

                Console.WriteLine("Enter part of a product name:");
                string input = Console.ReadLine();

                IQueryable<Product>? products = db.Products?
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                if (products is null)
                {
                    Console.WriteLine($"No product with {input} text");
                    return;
                }

                foreach (Product p in products)
                {
                    Console.WriteLine($"{0} has {1} units in stock. Discontinued? {2}",
                        p.ProductName, p.Stock, p.Discontinued);
                }

                Console.WriteLine();
            }
        }

        static bool AddProduct(int categoryId, string productName, decimal? price)
        {
            using (NorthwindContext db = new())
            {
                Product p = new()
                {
                    CategoryId = categoryId,
                    ProductName = productName,
                    Cost = price
                };

                _ = db.Products?.Add(p);                // mark product as added in change tracking

                int affected = db.SaveChanges();        // save change on db
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (NorthwindContext db = new())
            {
                Console.WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}", "Id", "Product Name", "Cost", "Stock", "Disc.");

                foreach (Product p in db.Products!.OrderByDescending(product => product.Cost))
                {
                    Console.WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
                }
            }
        }

        static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
        {
            using (NorthwindContext db = new())
            {
                Product updateProduct = db.Products!.First(p => p.ProductName.StartsWith(productNameStartsWith));
                updateProduct.Cost += amount;

                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static int DeleteProducts(string productNameStartsWith)
        {
            using (NorthwindContext db = new())
            {
                IQueryable<Product>? products = db.Products?.Where(
                    p => p.ProductName.StartsWith(productNameStartsWith));

                if (products is null)
                {
                    Console.WriteLine("No products fount to delete");
                    return 0;
                }
                else
                {
                    db.Products!.RemoveRange(products);
                }

                int affected = db.SaveChanges();
                return affected;

            }
        }

        // SaveChange method alway create an implicit transaction. In this method we show how to define explicit transaction
        static int DeleteProductsTransaction(string productNameStartsWith)
        {
            using (NorthwindContext db = new())
            {
                IQueryable<Product>? products = db.Products?.Where(
                    p => p.ProductName.StartsWith(productNameStartsWith));

                if (products is null)
                {
                    Console.WriteLine("No products fount to delete");
                    return 0;
                }
                else
                {
                    db.Products!.RemoveRange(products);
                }

                int affected = db.SaveChanges();
                return affected;

            }
        }
    }
}