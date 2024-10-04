using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.ViewModels.Table
{
    public class TablesAllViewModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public List<string> AvailableTimeSlots { get; set; }
    }
}
