using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public string? Phone { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
