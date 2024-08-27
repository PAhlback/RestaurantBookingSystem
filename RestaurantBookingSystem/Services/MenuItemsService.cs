using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Services
{
    public class MenuItemsService : IMenuItemsService
    {
        readonly IMenuItemsRepo _menuItemsRepo;

        public MenuItemsService(IMenuItemsRepo repo)
        {
            _menuItemsRepo = repo;
        }

        public async Task<List<MenuItem>> GetAll()
        {
            try
            {
                // Possibly change return value here to List<MenuItemViewModel>. 
                return await _menuItemsRepo.GetAllMenuItems(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MenuItem> GetById(int id)
        {
            try
            {
                return await _menuItemsRepo.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
