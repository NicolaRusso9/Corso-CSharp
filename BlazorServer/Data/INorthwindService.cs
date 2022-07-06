using CorsoCSharp.EFCore.AutoGenModels;

namespace BlazorServer.Data
{
    public interface INorthwindService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> GetCustomersAsync(string country);
        Task<Customer?> GetCustomerAsync(string id);
        Task<Customer> CreateCustomersAsync(Customer c);
        Task<Customer> UpdateCustomersAsync(Customer c);
        Task DeleteCustomersAsync(string id);

    }
}
