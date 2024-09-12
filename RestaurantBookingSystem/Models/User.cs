using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string NormalizedEmail { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Role { get; set; }
    }
}
