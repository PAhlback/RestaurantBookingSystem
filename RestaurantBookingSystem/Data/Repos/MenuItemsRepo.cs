using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos
{
    public class MenuItemsRepo : IMenuItemsRepo
    {
        private readonly ApplicationDbContext _context;

        public MenuItemsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllMenuItems()
        {
            try
            {
                List<MenuItem> menuItems = await _context.MenuItems.ToListAsync();

                return menuItems;
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
                MenuItem? menuItem = await _context.MenuItems.SingleOrDefaultAsync(i => i.Id == id);

                return menuItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
