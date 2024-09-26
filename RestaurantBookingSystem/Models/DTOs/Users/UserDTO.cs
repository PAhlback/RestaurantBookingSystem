using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.DTOs.Users
{
    public class UserDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
