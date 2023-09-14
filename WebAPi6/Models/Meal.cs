using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPi6.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("Subcategory")]
        public int SubcategoryId { get; set; }
        //[Required]
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        [ForeignKey("Restaurant")]
        public string RestaurantName { get; set; } = string.Empty;

    }
}
