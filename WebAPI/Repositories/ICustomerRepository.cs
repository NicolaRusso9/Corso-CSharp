using CorsoCSharp.EFCore.AutoGenModels;
namespace WebAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> CreateAsync(Customer c);
        Task<IEnumerable<Customer>> RetriveAllAsync();
        Task<Customer?> RetriveAsync(string id);
        Task<Customer?> UpdateAsync(string id, Customer c);
        Task<bool?> DeleteAsync(string id);
    }
}
