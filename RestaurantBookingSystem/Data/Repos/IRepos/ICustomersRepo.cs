
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.ViewModels;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface ICustomersRepo
    {
        Task AddCustomer(Customer newCustomer);
        Task<bool> CustomerEmailExists(string email);
        Task DeleteCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> GetCustomerById(int id);
        Task UpdateCustomer(Customer customer);
    }
}
