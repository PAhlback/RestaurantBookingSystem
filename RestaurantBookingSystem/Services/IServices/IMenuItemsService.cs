using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.MenuItem;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IMenuItemsService
    {
        Task AddMenuItem(MenuItemDTO dto);
        Task DeleteItem(int id);
        Task<ICollection<MenuItemViewModel>> GetAll();
        Task<MenuItemViewModel> GetById(int id);
        Task<ICollection<MenuItemViewModel>> GetPopular();
        Task UpdateMenuItem(int id, MenuItemDTO menuItemDTO);
    }
}
