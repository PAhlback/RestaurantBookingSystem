using System.ComponentModel.DataAnnotations;

namespace RestaurantBookingSystem.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}
