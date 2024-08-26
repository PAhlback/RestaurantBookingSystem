namespace RestaurantBookingSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime DateAndTime { get; set; }
        public Customer Customer { get; set; }
        
        public virtual ICollection<Table> Tables { get; set; }
    }
}
