using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
