using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;

namespace WebAPI.Repositories
{
    public class CustomerRepositories : ICustomerRepository
    {
        // use a static thread-safe dictionary field to cache the customers
        private static ConcurrentDictionary<string, Customer>? customerCache;

        private NorthwindContext db;

        public CustomerRepositories(NorthwindContext injectedContext)
        {
            db = injectedContext;

            // pre-load customers from database as a normal Dictionary with CustomerID as the key,
            // then convert to a thread-safe ConcurrentDictionary
            if (customerCache is null)
            {
                customerCache = new ConcurrentDictionary<string, Customer>(
                    db.Customers.ToDictionary(c=>c.CustomerId));
            }
        }


        public async Task<Customer?> CreateAsync(Customer c)
        {
            c.CustomerId = c.CustomerId.ToUpper();                          // Normalize customerid into uppurcase

            EntityEntry<Customer> added = await db.Customers.AddAsync(c);   // add to database using EF Core

            int affected = await db.SaveChangesAsync();                     // wait for saving changes

            if (affected == 1)
            {
                if (customerCache is null)
                {
                    return c;
                }

                // If the customer isnew, add it ot cache, else call updateCache method
                return customerCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        private Customer UpdateCache(string id, Customer c)
        {
            Customer? old;
            if(customerCache is not null)
            {
                if(customerCache.TryGetValue(id, out old))
                {
                    if(customerCache.TryUpdate(id,c, old))
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public Task<IEnumerable<Customer>> RetriveAllAsync()
        {
            // for performance get from cache
            return Task.FromResult(customerCache is null ? Enumerable.Empty<Customer>() : customerCache.Values);
        }

        public Task<Customer?> RetriveAsync(string id)
        {
            // for performance get from cache
            id= id.ToUpper();
            if (customerCache is null) return null;
            customerCache.TryGetValue(id, out Customer? c);
            return Task.FromResult(c);
        }

        public async Task<Customer?> UpdateAsync(string id, Customer c)
        {
            id = id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            db.Customers.Update(c);
            int affected = await db.SaveChangesAsync();

            if(affected == 1)
            {
                return UpdateCache(id, c);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();

            Customer? c = db.Customers.Find(id);
            if (c is null) return null;

            db.Customers.Remove(c);
            int affected = await db.SaveChangesAsync();

            if(affected == 1)
            {
                if(customerCache is null)
                {
                    return null;
                }

                return customerCache.TryRemove(id, out c);
            }

            return null;
        }
    }
}
