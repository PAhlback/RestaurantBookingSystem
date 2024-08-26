namespace RestaurantBookingSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
