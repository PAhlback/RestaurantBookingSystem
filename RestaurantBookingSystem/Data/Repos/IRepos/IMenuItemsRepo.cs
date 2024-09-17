using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface IMenuItemsRepo
    {
        Task AddMenuItem(MenuItem newMenuItem);
        Task DeleteMenuItem(MenuItem menuItem);
        Task<List<MenuItem>> GetAllMenuItems();
        Task<MenuItem> GetById(int id);
        Task<ICollection<MenuItem>> GetPopularItems();
        Task UpdateMenuItem(MenuItem menuItem);
    }
}
