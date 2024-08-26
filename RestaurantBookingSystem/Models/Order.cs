namespace RestaurantBookingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal OrderTotalPrice { get; set; } // Calculated property based on total value of MenuItems.
        public bool HasBeenPaid { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        
    }
}
