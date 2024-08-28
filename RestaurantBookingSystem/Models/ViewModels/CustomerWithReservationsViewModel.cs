using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.ViewModels
{
    public class CustomerWithReservationsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<CustomerReservationViewModel> Reservations { get; set; }
    }

    public class CustomerReservationViewModel
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
