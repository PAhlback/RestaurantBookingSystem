using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.DTOs
{
    public class MenuItemDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
