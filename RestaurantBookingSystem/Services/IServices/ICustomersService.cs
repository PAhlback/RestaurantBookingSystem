using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface ICustomersService
    {
        Task CreateCustomer(CustomerDTO dto);
        Task<bool> CustomerEmailExists(string email);
        Task DeleteCustomer(int id);
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerWithReservationsViewModel> GetCustomerById(int id);
        Task<Customer> GetCustomerByEmail(string email);
        Task UpdateCustomer(int id, CustomerDTO dto);
    }
}
