using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.ViewModels
{
    public class ReservationAllViewModel
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime DateAndTime { get; set; }

        public CustomerViewModel Customer { get; set; }

        public TablesAllViewModel Table { get; set; }
    }
}
