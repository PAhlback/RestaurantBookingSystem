using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.DTOs
{
    public class ReservationUpdateDTO
    {
        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string? CustomerPhone { get; set; }

        [Required]
        public int TableId { get; set; }
        [Required]
        public int? TableNumber { get; set; } // For manually selecting a new table number. Null indicates no change.
    }
}
