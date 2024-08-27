using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface IMenuItemsRepo
    {
        Task<List<MenuItem>> GetAllMenuItems();
        Task<MenuItem> GetById(int id);
    }
}
