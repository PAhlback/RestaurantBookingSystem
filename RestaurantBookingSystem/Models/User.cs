using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models
{
    public class User : IdentityUser
    {        
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Role { get; set; }
    }
}
