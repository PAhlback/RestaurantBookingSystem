using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IMenuItemsService
    {
        Task AddMenuItem(MenuItemDTO dto);
        Task DeleteItem(int id);
        Task<List<MenuItem>> GetAll();
        Task<MenuItem> GetById(int id);
        Task UpdateMenuItem(int id, MenuItemDTO menuItemDTO);
    }
}
