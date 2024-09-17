using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.MenuItem;
using RestaurantBookingSystem.Models.ViewModels.MenuItemCategory;
using RestaurantBookingSystem.Services.IServices;
using Sprache;
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
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            MenuItem newMenuItem = new MenuItem
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable,
                FK_CategoryId = dto.CategoryFK
            };

            await _menuItemsRepo.AddMenuItem(newMenuItem);
        }

        public async Task DeleteItem(int id)
        {
            MenuItem? menuItem = await _menuItemsRepo.GetById(id) ?? throw new KeyNotFoundException();

            await _menuItemsRepo.DeleteMenuItem(menuItem);
        }

        public async Task<ICollection<MenuItemViewModel>> GetAll()
        {
            var result = await _menuItemsRepo.GetAllMenuItems();

            ICollection<MenuItemViewModel> menuItems = result
                .Select(mi => new MenuItemViewModel
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    Description = mi.Description,
                    Price = mi.Price,
                    IsAvailable = mi.IsAvailable,
                    IsPopular = mi.IsPopular,
                    Category = mi.Category != null
                        ? new MenuItemCategoryNoItemsViewModel
                        {
                            Id = mi.Category.Id,
                            Name = mi.Category.Name
                        } : null
                })
                .ToList();

            return menuItems;
        }

        public async Task<MenuItem> GetById(int id)
        {
            MenuItem? menuItem = await _menuItemsRepo.GetById(id);

            if (menuItem == null)
            {
                throw new KeyNotFoundException($"No menu item with id {id} found.");
            }

            return menuItem;
        }

        public async Task<ICollection<MenuItemViewModel>> GetPopular()
        {
            ICollection<MenuItem> result = await _menuItemsRepo.GetPopularItems();

            ICollection<MenuItemViewModel> popularItems = result
                .Select(mi => new MenuItemViewModel
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    Description = mi.Description,
                    Price = mi.Price,
                    IsAvailable = mi.IsAvailable,
                    IsPopular = mi.IsPopular,
                    Category = mi.Category != null
                        ? new MenuItemCategoryNoItemsViewModel
                        {
                            Id = mi.Category.Id,
                            Name = mi.Category.Name
                        } : null
                })
                .ToList();

            return popularItems;
        }

        public async Task UpdateMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            ArgumentNullException.ThrowIfNull(menuItemDTO);

            MenuItem existingMenuItem = await _menuItemsRepo.GetById(id) as MenuItem ?? throw new KeyNotFoundException();

            if (menuItemDTO.Name != existingMenuItem.Name) existingMenuItem.Name = menuItemDTO.Name;
            if (menuItemDTO.Description != existingMenuItem.Description) existingMenuItem.Description = menuItemDTO.Description;
            if (menuItemDTO.Price != existingMenuItem.Price) existingMenuItem.Price = menuItemDTO.Price;
            if (menuItemDTO.IsAvailable != existingMenuItem.IsAvailable) existingMenuItem.IsAvailable = menuItemDTO.IsAvailable;

            await _menuItemsRepo.UpdateMenuItem(existingMenuItem);
        }
    }
}
