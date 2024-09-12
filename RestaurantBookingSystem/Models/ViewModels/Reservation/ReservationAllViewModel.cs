using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestaurantBookingSystem.Models.ViewModels.Customer;
using RestaurantBookingSystem.Models.ViewModels.Table;

namespace RestaurantBookingSystem.Models.ViewModels.Reservation
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
