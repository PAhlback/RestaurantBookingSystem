using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.DTOs
{
    public class ReservationDTO
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

        public bool? UtcTime { get; set; }
    }
}
