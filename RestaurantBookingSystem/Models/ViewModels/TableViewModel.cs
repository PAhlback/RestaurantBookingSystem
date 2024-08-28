using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.ViewModels
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }

        public virtual ICollection<TableReservationViewModel>? Reservations { get; set; }
    }

    public class TableReservationViewModel
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime DateAndTime { get; set; }

        // Customer info
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
