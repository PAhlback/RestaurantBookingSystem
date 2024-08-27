using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Services.IServices;
using System.Reflection.Metadata.Ecma335;

namespace RestaurantBookingSystem.Services
{
    public class MenuItemsService : IMenuItemsService
    {
        readonly IMenuItemsRepo _menuItemsRepo;

        public MenuItemsService(IMenuItemsRepo repo)
        {
            _menuItemsRepo = repo;
        }

        public async Task AddMenuItem(MenuItemDTO dto)
        {
            try
            {
                if (dto == null) throw new ArgumentNullException(nameof(dto));

                MenuItem newMenuItem = new MenuItem
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    IsAvailable = dto.IsAvailable
                };

                await _menuItemsRepo.AddMenuItem(newMenuItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
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
                MenuItem? menuItem = await _menuItemsRepo.GetById(id);

                if (menuItem == null)
                {
                    throw new Exception($"No menu item with id {id} found.");
                }

                return menuItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
