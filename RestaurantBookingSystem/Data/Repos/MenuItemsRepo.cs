using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;

namespace RestaurantBookingSystem.Data.Repos
{
    public class MenuItemsRepo : IMenuItemsRepo
    {
        private readonly ApplicationDbContext _context;

        public MenuItemsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMenuItem(MenuItem newMenuItem)
        {
            await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItem(MenuItem menuItem)
        {
            _context.Remove(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MenuItem>> GetAllMenuItems()
        {
            List<MenuItem> menuItems = await _context.MenuItems.Include(mi => mi.Category).ToListAsync();

            return menuItems;
        }

        public async Task<MenuItem> GetById(int id)
        {
            MenuItem? menuItem = await _context.MenuItems.Include(mi => mi.Category).SingleOrDefaultAsync(i => i.Id == id);

            return menuItem;
        }

        public async Task<ICollection<MenuItem>> GetPopularItems()
        {
            return await _context.MenuItems
                .Include(mi => mi.Category)
                .Where(mi => mi.IsPopular)
                .ToListAsync();
        }

        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
