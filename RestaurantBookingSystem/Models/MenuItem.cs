using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [ForeignKey("Category")]
        public int FK_CategoryId { get; set; }
        [Required]
        public MenuItemCategory Category { get; set; }

        public bool IsPopular { get; set; }
    }
}