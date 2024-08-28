using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.DTOs
{
    public class CustomerDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}
