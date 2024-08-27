using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IMenuItemsService
    {
        Task<List<MenuItem>> GetAll();
        Task<MenuItem> GetById(int id);
    }
}
