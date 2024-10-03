using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Models
{
    [Index("DateAndTime", "FK_TableId", IsUnique = true)]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        [Required]
        public Table Table { get; set; }
    }
}
