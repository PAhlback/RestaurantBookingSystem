using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestaurantBookingSystem.Models.ViewModels.MenuItemCategory;

namespace RestaurantBookingSystem.Models.ViewModels.MenuItem
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsAvailable { get; set; }
       
        public MenuItemCategoryNoItemsViewModel? Category { get; set; }

        public bool IsPopular { get; set; }
    }
}
