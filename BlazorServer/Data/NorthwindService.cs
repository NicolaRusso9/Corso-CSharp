using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data
{
    public class NorthwindService : INorthwindService
    {
        private readonly NorthwindContext db;

        public NorthwindService(NorthwindContext db)
        {
            this.db = db;
        }

        public Task<Customer> CreateCustomersAsync(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChangesAsync();
            return Task.FromResult<Customer>(c);
        }

        public Task DeleteCustomersAsync(string id)
        {
            Customer? customer = db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id).Result;

            if(customer == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                db.Customers.Remove(customer);
                return db.SaveChangesAsync();
            }
        }

        public Task<Customer?> GetCustomerAsync(string id)
        {
            return db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return db.Customers.ToListAsync();
        }

        public Task<List<Customer>> GetCustomersAsync(string country)
        {
            return db.Customers.Where(c=>c.Country==country).ToListAsync();
        }

        public Task<Customer> UpdateCustomersAsync(Customer c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChangesAsync();
            return Task.FromResult<Customer>(c);
        }
    }
}
