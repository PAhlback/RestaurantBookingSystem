using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface ICustomersService
    {
        Task AddCustomer(CustomerDTO dto);
        Task DeleteCustomer(int id);
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerWithReservationsViewModel> GetCustomerById(int id);
        Task UpdateCustomer(int id, CustomerDTO dto);
    }
}
